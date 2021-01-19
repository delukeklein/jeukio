using DesertStormZombies.Items;
using System;
using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    [Serializable]
    public struct Inventory
    {
        public Consumable PrimaryConsumable;
        public Consumable SecondaryConsumable;

        public Gun Primary;
        public Gun Secondary;
        public Knife Knife;

        public bool HasPrimaryConsumable => PrimaryConsumable != null;
        public bool HasSecondaryConsumable => SecondaryConsumable != null;
    }

    [Serializable]
    public struct InventoryInput
    {
        public KeyCode PrimaryKey;
        public KeyCode SecondaryKey;
        public KeyCode KnifeKey;
        public KeyCode PrimaryConsumableKey;
        public KeyCode SecondaryConsumableKey;

        public bool IsPrimaryPressed => Input.GetKeyDown(PrimaryKey);
        public bool IsSecondaryPressed => Input.GetKeyDown(SecondaryKey);
        public bool IsKnifePressed => Input.GetKeyDown(KnifeKey);
        public bool IsPrimaryConsumablePressed => Input.GetKeyDown(PrimaryConsumableKey);
        public bool IsSecondaryConsumablePressed => Input.GetKeyDown(SecondaryConsumableKey);
    }

    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;

        [SerializeField] private InventoryInput input;

        private Weapon equipped;

        void Update()
        {
            if (input.IsPrimaryPressed)
            {
                equipped = inventory.Primary;
            }
            else if (input.IsSecondaryPressed)
            {
                equipped = inventory.Secondary;
            }
            else if (input.IsKnifePressed)
            {
                equipped = inventory.Knife;
            }
            else if (input.IsPrimaryConsumablePressed && !inventory.HasPrimaryConsumable)
            {
                inventory.PrimaryConsumable.Consume();
                inventory.PrimaryConsumable = null;
            }
            else if (input.IsSecondaryConsumablePressed && !inventory.HasSecondaryConsumable)
            {
                inventory.SecondaryConsumable.Consume();
                inventory.SecondaryConsumable = null;
            }

            if(Input.GetMouseButton(0))
            {
                equipped.Attack();
            }

            if(Input.GetKeyDown(KeyCode.R) && equipped is Gun gun)
            {
                gun.Reload();
            }
        }
    }
}