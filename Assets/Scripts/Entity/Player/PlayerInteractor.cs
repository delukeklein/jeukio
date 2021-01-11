using DesertStormZombies.Interaction;

using UnityEngine;

namespace DesertStormZombies.Entity.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float distance;

        private Interactable interactable;

        private Ray InteractionRay => new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        private void Update()
        {
            if (interactable)
            {
                interactable.Focused(this);

                if (Input.GetKeyDown(KeyCode.E) && interactable.Condition(this))
                {
                    interactable.Interact(this);
                }
            }
        }

        private void FixedUpdate()
        {
            interactable = Physics.Raycast(InteractionRay, out RaycastHit hit, distance) ? hit.collider.GetComponent<Interactable>() : null;
        }
    }
}