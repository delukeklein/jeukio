using DesertStormZombies.Entity.Player;

using UnityEngine;

namespace DesertStormZombies.Interaction
{
    public class Generator : Interactable
    {
        [Header("Stats")]
        [SerializeField] private bool toggled = false;


        [Header("Pair")]
        [SerializeField] private Generator other;


        [Header("GO")]

        [SerializeField] private GameObject healthActive;
        [SerializeField] private GameObject fireRateActive;
        [SerializeField] private GameObject speedActive;
        [SerializeField] private GameObject fastReloadActive;

        [Header("")]

        [SerializeField] private GameObject healthInActive;
        [SerializeField] private GameObject fireRateInActive;
        [SerializeField] private GameObject speedInActive;
        [SerializeField] private GameObject fastReloadInActive;
        public bool Toggled => toggled;

        protected override void Start()
        {
            base.Start();

            healthActive.SetActive(false);
            fireRateActive.SetActive(false);
            speedActive.SetActive(false);
            fastReloadActive.SetActive(false);

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
                    healthActive.SetActive(true);
                    fireRateActive.SetActive(true);
                    speedActive.SetActive(true);
                    fastReloadActive.SetActive(true);

                    if (healthActive == true)
                    {
                        healthInActive.SetActive(false);
                    }
                    if (fireRateActive == true)
                    {
                        fireRateInActive.SetActive(false);
                    }
                    if (speedActive == true)
                    {
                        speedInActive.SetActive(false);
                    }
                    if (fastReloadActive == true)
                    {
                        fastReloadInActive.SetActive(false);
                    }
                }
            }
            
        }

        public override bool Condition(PlayerInteractor interactor)
        {
            return true;
        }

        private void Update()
        {
            
        }
    }

    
}

