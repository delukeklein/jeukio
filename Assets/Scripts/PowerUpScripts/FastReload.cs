using DesertStormZombies.Entity.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesertStormZombies.Interaction
{
    public class FastReload : Interactable
    {
        [Header("Cost")]

        [SerializeField] private int pointsCost;

        //[Header("Cost")]
        //[Header("Cost")]
        //[Header("Cost")]

        //[SerializeField] PlayerMovement playerMovement;

        public override bool Condition(PlayerInteractor interactor)
        {
            throw new System.NotImplementedException();
        }

        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText("Press E to interact\nCosts " + pointsCost + "points");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            pointsHolder -= pointsCost;

            Collider.enabled = false;

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
