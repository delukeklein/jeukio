using DesertStormZombies.Entity.Player;

using UnityEngine;

namespace DesertStormZombies.Interaction
{
    public class Generator : Interactable
    {
        [Header("Stats")]
        [SerializeField] private bool toggled = false;

        [SerializeField] private GameObject healthPowerUpActivate;
        [SerializeField] private GameObject fireRatePowerUpActivate;
        [SerializeField] private GameObject speedPowerUpActivate;
        [SerializeField] private GameObject fastReloadPowerUpActivate;

        [Header("Pair")]
        [SerializeField] private Generator other;

        public bool Toggled => toggled;

        protected override void Start()
        {
            base.Start();
        }

        public override void Focused(PlayerInteractor interactor)
        {  
            interactor.SetText(toggled ? "This generator is already activated" : "Press E to activate");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            if(!toggled)
            {
                toggled = true;

                if (other.Toggled)
                {
                    //doe wat er moet gebeuren als beide aan staan

                    healthPowerUpActivate.SetActive(true);
                    fireRatePowerUpActivate.SetActive(true);
                    speedPowerUpActivate.SetActive(true);
                    fastReloadPowerUpActivate.SetActive(true);
                }
            }
            
        }

        public override bool Condition(PlayerInteractor interactor)
        {
            return true;
        }
    }

}

