using System;
using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public class InputService : IInputService, IDisposable
    {
        private readonly InputSystem_Actions _actions;
 
        public InputService()
        {
            _actions = new InputSystem_Actions();
            _actions.Player.Enable();
        }
 
        public Vector2 GetMoveAxis() =>
            _actions.Player.Move.ReadValue<Vector2>();
 
        public Vector2 GetLookDelta() =>
            _actions.Player.Look.ReadValue<Vector2>();
 
        public bool HasMoveInput() =>
            GetMoveAxis() != Vector2.zero;
 
        public bool HasLookInput() =>
            GetLookDelta() != Vector2.zero;
 
        public bool GetInteractButtonDown() =>
            _actions.Player.Interact.WasPressedThisFrame();
 
        public bool GetDropButtonDown() =>
            _actions.Player.Drop.WasPressedThisFrame();
 
        public void Dispose()
        {
            _actions.Player.Disable();
            _actions.Dispose();
        }
    }
}