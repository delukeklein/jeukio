using DesertStormZombies.Entity.Player;
using DesertStormZombies.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesertStormZombies.Interaction
{
    public class AmmoBox : Interactable
    {
        [Header("Cost")]

        [SerializeField] private int pointsCost;
       
        [Header("Scripts")]
        [SerializeField] WeaponHolder weapon;

        [Header("Audio Source")]
        [SerializeField] AudioSource audioSource;

        

        public override bool Condition(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            return pointsHolder.Amount >= pointsCost;
        }

        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText("Press E to interact\nCosts " + pointsCost + "points");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            pointsHolder -= pointsCost;

            audioSource.Play();
        }

        protected override void Start()
        {
            base.Start();
        }

        void Update()
        {

        }
    }

}
