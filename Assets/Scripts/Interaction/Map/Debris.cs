using DesertStormZombies.Entity.Player;

using UnityEngine;

namespace DesertStormZombies.Interaction.Map
{
    public class Debris : Interactable
    {
        [SerializeField] private int pointsCost;

        [SerializeField] private float speed;

        [SerializeField] private Vector3 destination;

        private Collider[] colliders;

        private Vector3 startPosition;

        public bool Unlocked { get; private set; }

        public override void Focused(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            interactor.SetText("Press E to interact\nCosts " + (Condition(interactor) ? "<color=green>" : "<color=red>") + pointsCost + "</color>" + " points");
        }

        public override void Interact(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            pointsHolder -= pointsCost;

            Collider.enabled = false;

            foreach(Collider collider in colliders)
            {
                collider.enabled = false;
            }

            Unlocked = true;
        }

        public override bool Condition(PlayerInteractor interactor)
        {
            var pointsHolder = interactor.GetComponent<PointsHolder>();

            return pointsHolder.Amount >= pointsCost;
        }

        public void Restore()
        {
            transform.position = startPosition;

            Unlocked = false;
        }

        protected override void Start()
        {
            base.Start();

            startPosition = transform.position;

            colliders = GetComponentsInChildren<Collider>();
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