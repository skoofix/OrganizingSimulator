using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateHorizontalVelocitySystem>());
            Add(systems.Create<GravitySystem>());
 
            Add(systems.Create<CharacterControllerMoveSystem>());
        }
    }
}