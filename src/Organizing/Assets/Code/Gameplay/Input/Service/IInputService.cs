using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public interface IInputService
    {
        float GetVerticalAxis();
        float GetHorizontalAxis();
        bool HasAxisInput();
        bool GetJumpButtonDown();
        bool GetLeftMouseButtonDown();
        Vector2 GetScreenMousePosition();
        Vector2 GetWorldMousePosition();
        bool GetInteractButtonDown();
        bool GetDropButtonDown();
        bool GetLeftMouseButtonUp();
        float GetHorizontalMousePosition();
        float GetVerticalMousePosition();
        bool HasMouseAxisInput();
    }
}