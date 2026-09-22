using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : IState, IUpdateable
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;
        
        private GameLoopFeature _gameLoopFeature;

        public BattleLoopState(ISystemFactory systems, GameContext gameContext)
        {
            _systems = systems;
            _gameContext = gameContext;
        }
    
        public void Enter()
        {
            _gameLoopFeature = _systems.Create<GameLoopFeature>();
            _gameLoopFeature.Initialize();
        }

        public void Update()
        {
            _gameLoopFeature.Execute();
            _gameLoopFeature.Cleanup();
        }

        public void Exit()
        {
            _gameLoopFeature.DeactivateReactiveSystems();
            _gameLoopFeature.ClearReactiveSystems();

            DestructEntities();
            
            _gameLoopFeature.Cleanup();
            _gameLoopFeature.TearDown();
            _gameLoopFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
            {
               // entity.isDestructed = true;
            }
        }
    }
}