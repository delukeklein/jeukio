using DesertStormZombies.Entity.Player;

namespace DesertStormZombies.Items
{
    public interface Consumable
    {
        void Consume(PlayerInventory playerInventory);
    }
}
