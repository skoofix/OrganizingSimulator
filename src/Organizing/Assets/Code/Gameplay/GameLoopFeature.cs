using Code.Common.Destruct;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class GameLoopFeature : Feature
    {
        public GameLoopFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());

            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}