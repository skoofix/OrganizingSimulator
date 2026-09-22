using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly GameContext _gameContext;
        private GameLoopFeature _battleFeature;

        public BattleEnterState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    
        public void Enter()
        {
            PlaceHero();  
      
            _stateMachine.Enter<BattleLoopState>();
        }

        private void PlaceHero()
        {
        }

        public void Exit()
        {
      
        }
    }
}