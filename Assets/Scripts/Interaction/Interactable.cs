using DesertStormZombies.Entity.Player;

using UnityEngine;

namespace DesertStormZombies.Interaction
{
    [RequireComponent(typeof(Collider))]
    public abstract class Interactable : MonoBehaviour
    {
        protected Collider Collider { get; private set; }

        protected virtual void Start() => Collider = GetComponent<Collider>();

        public abstract void Interact(PlayerInteractor interactor);

        public abstract void Focused(PlayerInteractor interactor);

        public abstract bool Condition(PlayerInteractor interactor);
    }
}

