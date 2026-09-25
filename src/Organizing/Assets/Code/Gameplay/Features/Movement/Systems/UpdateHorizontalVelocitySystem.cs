using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateHorizontalVelocitySystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public UpdateHorizontalVelocitySystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.Direction,
                    GameMatcher.Speed,
                    GameMatcher.Acceleration,
                    GameMatcher.Deceleration));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                Vector3 velocity = mover.Velocity;

                float currentSpeed = new Vector3(velocity.x, 0, velocity.z).magnitude;

                float targetSpeed = mover.isMoving
                    ? mover.Speed
                    : 0f;

                float changeRate = mover.isMoving
                    ? mover.Acceleration
                    : mover.Deceleration;

                float newSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, changeRate * _time.DeltaTime);
                
                Vector3 horizontalVelocity = mover.Direction.normalized * newSpeed;

                mover.ReplaceVelocity(new Vector3(horizontalVelocity.x, velocity.y, horizontalVelocity.z));
            }
        }
    }
}