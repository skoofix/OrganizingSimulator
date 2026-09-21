using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.Physics
{
    public interface IPhysicsService
    {
        GameEntity Raycast(Vector3 worldPosition, Vector3 direction, float maxDistance, int layerMask);
        GameEntity LineCast(Vector3 start, Vector3 end, int layerMask);
        IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
        IEnumerable<GameEntity> OverlapSphere(Vector3 position, float radius, int layerMask);
        int OverlapSphereNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
        int OverlapSphereColliders(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
    }
}