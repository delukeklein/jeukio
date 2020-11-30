using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyHit : MonoBehaviour
{
    private Health health;

    private void Start() => health = GetComponent<Health>();

    private void OnCollisionEnter(Collision collision)
    {
        BulletScript bullet;

        if(collision.gameObject.TryGetComponent(out bullet))
        {
            health.Reduce(25);

            if(health.isDepleted)
            {
                Destroy(gameObject);
            }
        }
    }
}
