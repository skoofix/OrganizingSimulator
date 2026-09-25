using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext input, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = input.GetGroup(GameMatcher.Input);
        }
    
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.HasMoveInput())
                    input.ReplaceAxisInput(_inputService.GetMoveAxis());
                else if (input.hasAxisInput)
                    input.RemoveAxisInput();
                
                input.isDropInput = _inputService.GetDropButtonDown();
                input.isInteractInput = _inputService.GetInteractButtonDown();
            }
        }
    }
}