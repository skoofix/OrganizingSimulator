using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public interface IInputService
    {
        Vector2 GetMoveAxis();
        Vector2 GetLookDelta();
 
        bool HasMoveInput();
        bool HasLookInput();
 
        bool GetInteractButtonDown();
        bool GetDropButtonDown();
    }
}