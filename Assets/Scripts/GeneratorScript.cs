using DesertStormZombies.Entity.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesertStormZombies.Interaction
{
    public class GeneratorScript : Interactable
    {

        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText("Press E to Activate");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            Collider.enabled = false;

           

        }

        public override bool Condition(PlayerInteractor interactor)
        {
            return true; 
        }


        [Header("Generators")]

       [SerializeField] GameObject Generator1;
       [SerializeField] GameObject Generator2;

        [Header("Bool")]

        [SerializeField] bool Generator1State = false;
        [SerializeField] bool Generator2State = false;

        [SerializeField] bool HealthPowerUpActivate = false;
        [SerializeField] bool FireRatePowerUpActivate = false;
        [SerializeField] bool SpeedPowerUpActivate = false;
        [SerializeField] bool FastReloadPowerUpActivate = false;

        [Header("Script")]

        [SerializeField] GeneratorScript generatorScript;

        protected override void Start()
        {
            base.Start();

        }

        void Update()
        {
            
        }
    }

}

