using Code.Gameplay.Features.Look.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Look
{
    public class LookFeature : Feature
    {
        public LookFeature(ISystemFactory systems)
        {
            Add(systems.Create<AttachCameraToPlayerHeadSystem>());
 
            Add(systems.Create<UpdateLookRotationSystem>());
        }
    }
}