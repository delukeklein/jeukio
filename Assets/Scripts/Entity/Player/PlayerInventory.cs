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

        public WeaponData Primary;
        public WeaponData Secondary;
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
}