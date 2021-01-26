using UnityEngine;

namespace DesertStormZombies.Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Desert Storm Zombies/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public int Damage;

        public float FireRate;
        public float ReloadSpeed;

        public GameObject Model;
    }
}
