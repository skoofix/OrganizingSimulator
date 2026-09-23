using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    public class InputComponents
    {
        [Game] public class Input : IComponent { }
        [Game] public class AxisInput : IComponent { public Vector2 Value; }
        [Game] public class MouseAxisInput : IComponent { public Vector2 Value; }
        [Game] public class InteractInput : IComponent { }
        [Game] public class DropInput : IComponent { }
    }
}