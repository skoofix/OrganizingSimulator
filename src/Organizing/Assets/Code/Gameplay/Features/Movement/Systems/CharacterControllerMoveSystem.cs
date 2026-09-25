using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class CharacterControllerMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public CharacterControllerMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CharacterController,
                    GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.CharacterController.Move(mover.Velocity * _time.DeltaTime);
            }
        }
    }
}