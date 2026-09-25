using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class GravitySystem : IExecuteSystem
    {
        private const float GroundedVerticalVelocity = -5f;

        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public GravitySystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CharacterController,
                    GameMatcher.Velocity,
                    GameMatcher.Gravity));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                Vector3 velocity = mover.Velocity;

                if (mover.CharacterController.isGrounded)
                    velocity.y = GroundedVerticalVelocity;
                else
                    velocity.y += mover.Gravity * _time.DeltaTime;

                mover.ReplaceVelocity(velocity);
            }
        }
    }
}