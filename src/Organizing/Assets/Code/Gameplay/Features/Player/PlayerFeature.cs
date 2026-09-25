using Code.Gameplay.Features.Player.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Player
{
    public class PlayerFeature : Feature
    {
    public PlayerFeature(ISystemFactory systems)
    {
        Add(systems.Create<SetPlayerLookByInputSystem>());
        Add(systems.Create<SetPlayerDirectionByInputSystem>());
    }
    }
}