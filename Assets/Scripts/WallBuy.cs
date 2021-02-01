using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesertStormZombies.Entity;
using DesertStormZombies.Entity.Player;
using DesertStormZombies.Game;
using DesertStormZombies.Utility;
using DesertStormZombies.Items;

namespace DesertStormZombies.Interaction
{
    public class WallBuy : Interactable
    {
        [Header("Cost")]

        [SerializeField] private int pointsCost;

        [Header("Scripts")]
        [SerializeField] WeaponHolder weapon;
        [SerializeField] PlayerInventory playerInventory;
        [SerializeField] WeaponData weaponData;

        public EquippedItem equipped;

        public override bool Condition(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            return pointsHolder.Amount >= pointsCost;
        }

        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText("Press E to buy\nCosts " + pointsCost + "points");
        }

        public override void Interact(PlayerInteractor interactor)
        {
             var pointsHolder = interactor.GetComponent<PointsHolder>();

             pointsHolder -= pointsCost;

             playerInventory.SetPrimary(weaponData);
        }
        protected override void Start()
        {
            base.Start();
            weapon.GetComponent<WeaponHolder>();
        }

        void Update()
        {

        }
    }
}
