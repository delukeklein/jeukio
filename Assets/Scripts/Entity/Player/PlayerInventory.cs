﻿using DesertStormZombies.Items;

using System;

using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    public enum EquippedItem 
    { 
        Primary, 
        Secondary, 
        Knife,
        PrimaryConsumable,
        SecondaryConsumable
    }

    [Serializable]
    public struct Inventory
    {
        public Consumable PrimaryConsumable;
        public Consumable SecondaryConsumable;

        public WeaponData Primary;
        public WeaponData Secondary;
        public WeaponData Knife;

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
        [SerializeField] private WeaponHolder weaponHolder;

        [SerializeField] private Inventory inventory;

        [SerializeField] private InventoryInput input;

        private EquippedItem equipped;

        public WeaponHolder GetWeaponHolder => weaponHolder;

        private void Start()
        {
            equipped = EquippedItem.Knife;
            weaponHolder.SetWeaponData(inventory.Knife);
        }

        private void Update()
        {
            SwitchItem();

            if (Input.GetMouseButtonDown(0))
            {
                weaponHolder.ShootAnimation.Play();

                if (inventory.PrimaryConsumable != null && equipped == EquippedItem.PrimaryConsumable)
                {
                    inventory.PrimaryConsumable.Consume(this);
                    inventory.PrimaryConsumable = null;
                }

                if (inventory.SecondaryConsumable != null && equipped == EquippedItem.SecondaryConsumable)
                {
                    inventory.SecondaryConsumable.Consume(this);
                    inventory.SecondaryConsumable = null;
                }
            }
    
        }

        private void SwitchItem()
        {
            if(input.IsPrimaryPressed)
            {
                equipped = EquippedItem.Primary;
                weaponHolder.SetWeaponData(inventory.Primary);
            }
            else if (input.IsSecondaryPressed)
            {
                equipped = EquippedItem.Secondary;
                weaponHolder.SetWeaponData(inventory.Secondary);
            }
            else if (input.IsKnifePressed)
            {
                equipped = EquippedItem.Knife;
                weaponHolder.SetWeaponData(inventory.Knife);
            }
            else if(input.IsPrimaryConsumablePressed)
            {
                equipped = EquippedItem.PrimaryConsumable;
                weaponHolder.SetWeaponData(null);
            } 
            else if(input.IsSecondaryConsumablePressed)
            { 
                equipped = EquippedItem.SecondaryConsumable;
                weaponHolder.SetWeaponData(null);
            }
        }
    }
}