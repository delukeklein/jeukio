using DesertStormZombies.Entity.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesertStormZombies.Interaction
{
    public class RapidFire : Interactable
    {
        [SerializeField] private int pointsCost;

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
