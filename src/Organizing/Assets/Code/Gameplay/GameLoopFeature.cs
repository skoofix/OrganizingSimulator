using Code.Common.Destruct;
using Code.Gameplay.Features.Look;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Player;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class GameLoopFeature : Feature
    {
        public GameLoopFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
          //  Add(systems.Create<BindViewFeature>());
 
            Add(systems.Create<PlayerFeature>());
            Add(systems.Create<LookFeature>());
            Add(systems.Create<MovementFeature>());
 
          //  Add(systems.Create<InteractionFeature>());
          //  Add(systems.Create<CarryingFeature>());
 
          //  Add(systems.Create<ApplyHiddenViewSystem>());
          //  Add(systems.Create<UpdateLastPositionSystem>());
 
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}