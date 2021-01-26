using UnityEngine;

namespace DesertStormZombies.Entity
{
    public class Health : MonoBehaviour
    {
        [SerializeField] public int health;

        [SerializeField] public int maxHealth;

        public bool isDepleted => health <= 0;

        public int CurrentHealth => health;

        public int MaxHealth => maxHealth;

        public void Heal(uint amount) => health = (int)Mathf.Clamp(health + amount, 0, maxHealth);

        public void Reduce(uint amount) => health -= (int)amount;

        public void Start() => health = Mathf.Clamp(health, 0, maxHealth);
    }
}