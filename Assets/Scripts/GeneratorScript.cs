using DesertStormZombies.Entity.Player;
using DesertStormZombies.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesertStormZombies.Interaction
{
    public class GeneratorScript : Interactable
    {
        public override void Focused(PlayerInteractor interactor)
        {
            interactor.SetText("Press E to Active");

        }

        public override void Interact(PlayerInteractor interactor)
        {
            Collider.enabled = false;


            Generator1Active = true;

            if (Generator1Active && Generator2Active == true)
            {
                FastReloadActive.SetActive(true);
                RapidFireActive.SetActive(true);
                HealthUpActive.SetActive(true);
                SpeedOActive.SetActive(true);
            }

        }

        public override bool Condition(PlayerInteractor interactor)
        {
            return true;
        }

        [Header("Generators")]

        [SerializeField] GameObject Generator1;
        [SerializeField] GameObject Generator2;

        [Header("PowerUps")]

        [SerializeField] GameObject FastReloadActive;
        [SerializeField] GameObject RapidFireActive;
        [SerializeField] GameObject HealthUpActive;
        [SerializeField] GameObject SpeedOActive;



        [Header("Boollean")]
        [SerializeField] bool Generator1Active = false;
        [SerializeField] bool Generator2Active = false;

        //[Header("ECT")]



        protected override void Start()
        {
            base.Start();

            FastReloadActive.SetActive(false);
            RapidFireActive.SetActive(false);
            HealthUpActive.SetActive(false);
            SpeedOActive.SetActive(false);
        }

        void Update()
        {

        }
    }
}
