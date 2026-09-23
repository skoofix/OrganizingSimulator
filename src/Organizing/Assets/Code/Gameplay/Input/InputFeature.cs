using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            
         //   Add(systems.Create<LockCursorSystem>());
            Add(systems.Create<InitializeInputSystem>());
            Add(systems.Create<EmitInputSystem>());
         //   Add(systems.Create<EmitMouseInputSystem>());
         //   Add(systems.Create<EmitInteractInputSystem>());
         //   Add(systems.Create<EmitDropInputSystem>());
        }
    }
}