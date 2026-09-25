using Entitas;
using UnityEngine;

namespace Code.Gameplay.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class CharacterControllerComponent : IComponent { public CharacterController Value; }
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
}