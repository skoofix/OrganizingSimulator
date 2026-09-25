using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Registrar
{
    public class PlayerRegistrar : EntityComponentRegistrar
    {
        public float CarrySmoothing = 12f;
        public float DropImpulse = 1.5f;
        public CharacterController CharacterController;
        public float Speed = 2;
        public Transform Head;
        public float LookSensitivity = 2f;
        public float InteractDistance = 3f;
        public Transform HoldPoint;
        
        public override void RegisterComponents()
        {
            Entity
                .AddGravity(-20f)
                .AddSpeed(Speed)
                .AddAcceleration(40)
                .AddDeceleration(60)
                .AddDirection(Vector3.zero)
                .AddVelocity(Vector3.zero)
                .AddHead(Head)
                .AddLookSensitivity(LookSensitivity)
                .AddYaw(transform.eulerAngles.y)
                .AddPitch(0)
                .AddCharacterController(CharacterController)
                .With(x => x.isPlayer = true);
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}