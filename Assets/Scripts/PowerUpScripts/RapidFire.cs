using DesertStormZombies.Entity.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesertStormZombies.Interaction
{
    public class RapidFire : Interactable
    {
        [Header("Cost")]

        [SerializeField] private int pointsCost;

        // [Header("")]
        //[SerializeField] PlayerMovement playerMovement;

        [Header("Stats")]

        //[SerializeField] float playerWalkSpeed;
       // [SerializeField] float playerRunningSpeed;

        [Header("Scripts")]
       //[SerializeField] PlayerMovement playerMovement;


        [Header("Bools")]
        [SerializeField] private bool toggled = false;
        public bool Toggled => toggled;

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
                }
            }
        }

        protected override void Start()
        {
            base.Start();
            //playerHealth.GetComponent<Health>();
            
        }

        void Update()
        {

        }
    }

}
