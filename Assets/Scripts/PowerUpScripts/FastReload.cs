using DesertStormZombies.Entity.Player;
using DesertStormZombies.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesertStormZombies.Interaction
{
    public class FastReload : Interactable
    {
        [Header("Cost")]

        [SerializeField] private int pointsCost;

        [Header("Stats")]

        [SerializeField] float reloadSpeed;

        [Header("Scripts")]
        [SerializeField] WeaponHolder weapon;


        [Header("Bools")]
        [SerializeField] private bool toggled = false;
        public bool Toggled => toggled;

        [Header("Particle")]
       [SerializeField] ParticleSystem part;

        public override bool Condition(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            return pointsHolder.Amount >= pointsCost;
        }

        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText(toggled ? "This PowerUp is already Used" : "Press E to interact\nCosts " + pointsCost + "points");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            if (!toggled)
            {
                toggled = true;

                if (Toggled == true)
                {
                    var pointsHolder = interactor.GetComponent<PointsHolder>();

                    pointsHolder -= pointsCost;
                  
                    reloadSpeed = weapon.reloadSpeedModifier = 2;

                    part.gameObject.SetActive(true);
                    

                }
            }
        }

        protected override void Start()
        {
            base.Start();
            weapon.GetComponent<WeaponHolder>();
            part.GetComponent<ParticleSystem>();
        }

        void Update()
        {
           
        }
    }
}
