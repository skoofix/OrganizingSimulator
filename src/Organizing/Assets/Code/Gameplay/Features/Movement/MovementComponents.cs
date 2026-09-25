using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
        [Game] public class Speed : IComponent { public float Value; }
        [Game] public class Acceleration : IComponent { public float Value; }
        [Game] public class Deceleration : IComponent { public float Value; }
        [Game] public class Direction : IComponent { public Vector3 Value; }
        [Game] public class Velocity : IComponent { public Vector3 Value; }
        [Game] public class Gravity : IComponent { public float Value; }
        [Game] public class Moving : IComponent { }
}