using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
    public class SetPlayerLookByInputSystem : IExecuteSystem
    {
        private const float DegreesPerMouseCount = 0.022f;

        private const float FullTurn = 360f;
        private const float MinPitch = -85f;
        private const float MaxPitch = 85f;

        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _players;

        public SetPlayerLookByInputSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input,
                    GameMatcher.MouseAxisInput));

            _players = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Yaw,
                    GameMatcher.Pitch,
                    GameMatcher.LookSensitivity));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity player in _players)
            {
                Vector2 lookDelta = input.MouseAxisInput * player.LookSensitivity * DegreesPerMouseCount;
                
                player.ReplaceYaw(Mathf.Repeat(player.Yaw + lookDelta.x, FullTurn));
                player.ReplacePitch(Mathf.Clamp(player.Pitch - lookDelta.y, MinPitch, MaxPitch));
            }
        }
    }
}