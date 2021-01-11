using DesertStormZombies.Entity.Player;

using UnityEngine;

namespace DesertStormZombies.Entity.Enemy
{
    [RequireComponent(typeof(Health))]
    public class EnemyHit : MonoBehaviour
    {
        private Health health;

        private PointsHolder pointsHolder;

        private void OnEnable()
        {
            health = GetComponent<Health>();
            pointsHolder = FindObjectOfType<PointsHolder>().GetComponent<PointsHolder>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out BulletScript bullet))
            {
                pointsHolder += 10;

                health.Reduce(25);

                if (health.isDepleted)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}