using DesertStormZombies.Items;

using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int maxConsumables;

        private Consumable[] consumables;

        private Weapon primaire;
        private Weapon second;
        private Weapon knife;

        private EquippedWeapon equippedWeapon;

        void Start()
        {
            consumables = new Consumable[maxConsumables];
        }

        void Update()
        {

        }

        public void TransitionToItem()
        {

        }
    }

    public enum EquippedWeapon
    {
        Primair,
        Second,
        Knife
    }
}