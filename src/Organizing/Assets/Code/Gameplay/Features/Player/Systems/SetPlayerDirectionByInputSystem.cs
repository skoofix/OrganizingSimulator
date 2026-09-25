using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
    public class SetPlayerDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _heroes;

        public SetPlayerDirectionByInputSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.Input);
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Direction,
                    GameMatcher.Yaw));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                {
                    Vector3 localDirection = new Vector3(input.AxisInput.x, 0, input.AxisInput.y);
                    Vector3 worldDirection = Quaternion.Euler(0, hero.Yaw, 0) * localDirection;

                    hero.ReplaceDirection(Vector3.ClampMagnitude(worldDirection, 1f));
                }
            }
        }
    }
}