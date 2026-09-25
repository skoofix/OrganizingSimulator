using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Look.Systems
{
    public class UpdateLookRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _lookers;

        public UpdateLookRotationSystem(GameContext game)
        {
            _lookers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Head,
                    GameMatcher.Yaw,
                    GameMatcher.Pitch));
        }

        public void Execute()
        {
            foreach (GameEntity looker in _lookers)
            {
                looker.Transform.rotation = Quaternion.Euler(0, looker.Yaw, 0);
                looker.Head.localRotation = Quaternion.Euler(looker.Pitch, 0, 0);
            }
        }
    }
}