using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Collisions;
using UnityEngine;
using UnityPhysics = UnityEngine.Physics;

namespace Code.Gameplay.Common.Physics
{
    public class PhysicsService : IPhysicsService
    {
        private const float DebugDrawSeconds = 1f;
        private const QueryTriggerInteraction TriggerInteraction = QueryTriggerInteraction.Collide;

        private static readonly RaycastHit[] Hits = new RaycastHit[128];
        private static readonly Collider[] OverlapHits = new Collider[128];
        private static readonly RaycastHitDistanceComparer HitDistanceComparer = new();

        private readonly ICollisionRegistry _collisionRegistry;

        public PhysicsService(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask)
        {
            int hitCount = RaycastNonAlloc(worldPosition, direction, Mathf.Infinity, layerMask);
            Array.Sort(Hits, 0, hitCount, HitDistanceComparer);

            for (int i = 0; i < hitCount; i++)
            {
                GameEntity entity = EntityOf(Hits[i].collider);
                if (entity == null)
                    continue;

                yield return entity;
            }
        }

        public GameEntity Raycast(Vector3 worldPosition, Vector3 direction, float maxDistance, int layerMask) =>
            ClosestEntity(worldPosition, direction, maxDistance, layerMask);

        public GameEntity LineCast(Vector3 start, Vector3 end, int layerMask)
        {
            Vector3 delta = end - start;
            float distance = delta.magnitude;

            if (distance < Mathf.Epsilon)
                return null;

            return ClosestEntity(start, delta / distance, distance, layerMask);
        }

        public IEnumerable<GameEntity> OverlapSphere(Vector3 position, float radius, int layerMask)
        {
            int hitCount = OverlapSphereColliders(position, radius, OverlapHits, layerMask);

            DrawDebug(position, radius, DebugDrawSeconds, Color.red);

            for (int i = 0; i < hitCount; i++)
            {
                GameEntity entity = EntityOf(OverlapHits[i]);
                if (entity == null)
                    continue;

                yield return entity;
            }
        }

        public int OverlapSphereNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer)
        {
            int hitCount = OverlapSphereColliders(position, radius, OverlapHits, layerMask);

            DrawDebug(position, radius, DebugDrawSeconds, Color.green);

            int entityCount = 0;
            for (int i = 0; i < hitCount && entityCount < hitBuffer.Length; i++)
            {
                GameEntity entity = EntityOf(OverlapHits[i]);
                if (entity == null)
                    continue;

                hitBuffer[entityCount++] = entity;
            }

            return entityCount;
        }

        public int OverlapSphereColliders(Vector3 worldPos, float radius, Collider[] hits, int layerMask) =>
            UnityPhysics.OverlapSphereNonAlloc(worldPos, radius, hits, layerMask, TriggerInteraction);

        private GameEntity ClosestEntity(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
        {
            int hitCount = RaycastNonAlloc(origin, direction, maxDistance, layerMask);

            GameEntity closestEntity = null;
            float closestDistance = float.MaxValue;

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];
                if (hit.distance >= closestDistance)
                    continue;

                GameEntity entity = EntityOf(hit.collider);
                if (entity == null)
                    continue;

                closestEntity = entity;
                closestDistance = hit.distance;
            }

            return closestEntity;
        }

        private static int RaycastNonAlloc(Vector3 origin, Vector3 direction, float maxDistance, int layerMask) =>
            UnityPhysics.RaycastNonAlloc(origin, direction, Hits, maxDistance, layerMask, TriggerInteraction);

        private GameEntity EntityOf(Collider collider) =>
            collider != null
                ? _collisionRegistry.Get<GameEntity>(collider.GetInstanceID())
                : null;

        private static void DrawDebug(Vector3 worldPos, float radius, float seconds, Color color)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.forward, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.back, color, seconds);
        }

        private class RaycastHitDistanceComparer : IComparer<RaycastHit>
        {
            public int Compare(RaycastHit x, RaycastHit y) =>
                x.distance.CompareTo(y.distance);
        }
    }
}