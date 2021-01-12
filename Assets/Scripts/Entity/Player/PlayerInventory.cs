using DesertStormZombies.Items;

using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        private Consumable primaryConsumable;
        private Consumable secondaryConsumable;

        private Gun primary;
        private Gun secondary;
        private Knife knife;

        private Weapon current;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                current = primary;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                current = secondary;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                current = knife;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && primaryConsumable != null)
            {
                primaryConsumable.Consume();
                primaryConsumable = null;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && secondaryConsumable != null)
            {
                secondaryConsumable.Consume();
                secondaryConsumable = null;
            }

            if(Input.GetMouseButton(0))
            {
                current.Attack();
            }

            if(Input.GetKeyDown(KeyCode.R) && current == primary || current == secondary)
            {
                ((Gun)current).Reload();
            }
        }

        public void SetPrimary(Gun primary) => this.primary = primary;

        public void SetSecondary(Gun secondary) => this.secondary = secondary;

        public void SetKnife(Knife knife) => this.knife = knife;

        public void SetPrimaryConsumable(Consumable primaryConsumable) => this.primaryConsumable = primaryConsumable;

        public void SetSecondaryConsumable(Consumable secondaryConsumable) => this.secondaryConsumable = secondaryConsumable;
    }
}