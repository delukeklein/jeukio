using DesertStormZombies.Entity.Player;
using DesertStormZombies.Game;

using UnityEngine;

namespace DesertStormZombies.Interaction.Map
{
    public class Debris : Interactable
    {
        [SerializeField] private int pointsCost;
        [SerializeField] private int minimumWave;

        [SerializeField] private float speed;

        [SerializeField] private Vector3 destination;

        private Vector3 startPosition;

        public bool Unlocked { get; private set; }

        protected override void Start()
        {
            base.Start();

            startPosition = transform.position;
        }

        public override void Focused(PlayerInteractor interactor)
        {
            //UI;
        }

        public override void Interact(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            pointsHolder -= pointsCost;

            Collider.enabled = false;

            Unlocked = true;
        }

        public override bool Condition(PlayerInteractor interactor)
        {
            var waves = interactor.GetComponent<GameWaves>();
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            return pointsHolder.Amount >= pointsCost && waves.Wave >= minimumWave;
        }

        public void Restore()
        {
            transform.position = startPosition;

            Unlocked = false;
        }

        private void Update()
        {
            if (Unlocked)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }
        }
    }
}