using DesertStormZombies.Utility;
using System.Collections;
using UnityEngine;

namespace DesertStormZombies.Items
{
    public class Gun : Weapon
    {
        [SerializeField] private int damage;
        [SerializeField] private int reloadSpeed;

        [SerializeField] private float fireRate;

        [SerializeField] private Magazine magazine;

        public override void Attack()
        {

        }

        [SerializeField]
        private struct Magazine
        {
            public int Current;
            public int Max;

            public bool IsEmpty => Current == 0;

            public bool IsFull => Current == Max;
        }
    }
}