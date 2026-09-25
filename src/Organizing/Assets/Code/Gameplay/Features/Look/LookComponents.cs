using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Look
{
    [Game] public class Head : IComponent { public Transform Value; }
    [Game] public class Yaw : IComponent { public float Value; }
    [Game] public class Pitch : IComponent { public float Value; }
    [Game] public class LookSensitivity : IComponent { public float Value; }
    [Game] public class CameraAttached : IComponent { }
}