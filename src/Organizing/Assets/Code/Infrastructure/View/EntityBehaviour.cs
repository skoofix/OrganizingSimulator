using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry) => 
            _collisionRegistry = collisionRegistry;

        public GameEntity Entity => _entity;

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();
            
            foreach (Collider collider3d in GetComponentsInChildren<Collider>(includeInactive: true)) 
                _collisionRegistry.Register(collider3d.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents();
            
            foreach (Collider collider3d in GetComponentsInChildren<Collider>(includeInactive: true)) 
                _collisionRegistry.Unregister(collider3d.GetInstanceID());
            
            _entity.Release(this);
            _entity = null;
        }
    }
}