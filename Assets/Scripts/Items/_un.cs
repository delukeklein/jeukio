using DesertStormZombies.Utility;

using UnityEngine;

namespace DesertStormZombies.Items
{
    public class Gun : Weapon
    {
        [SerializeField] private int damage;
        [SerializeField] private int reloadSpeed;

        [SerializeField] private float fireRate;

        [SerializeField] Transform shootingPoint;

        private IntervalTimer intervalTimer;

        protected override void Start()
        {
            intervalTimer = new IntervalTimer(fireRate);
        }

        public override void Attack()
        {
            if(intervalTimer.Check(Time.deltaTime))
            {
                //raycast
            }
        }

        public void Reload()
        {
            //reload;
        }
    }
}