using DesertStormZombies.Entity;
using DesertStormZombies.Utility;

using UnityEngine;

namespace DesertStormZombies.Items
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class WeaponHolder : MonoBehaviour
    {
        [Header("Weapon Data")]
        [SerializeField] private float damageModifier;
        [SerializeField] private float fireRateModifier;
        [SerializeField] private float reloadSpeedModifier;

        private WeaponData weaponData;

        private IntervalTimer fireRateTimer;

        private MeshFilter meshFilter;
        private MeshRenderer meshRenderer;

        private bool HoldingWeapon => weaponData != null;

        private Ray ShotRay => new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        private void Awake()
        {
            fireRateTimer = new IntervalTimer(0);

            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if(!HoldingWeapon)
            {
                return;
            }

            fireRateTimer.Interval = weaponData.FireRate * fireRateModifier;

            if (Input.GetMouseButton(0) && fireRateTimer.Check(Time.deltaTime))
            {
                Debug.LogWarning("Shot");

                if(Physics.Raycast(ShotRay, out RaycastHit hit, 1000) && hit.collider.TryGetComponent(out Health health))
                {
                    health.Reduce((uint)(weaponData.Damage * damageModifier));
                }
            }
        }

        public void SetWeaponData(WeaponData weaponData)
        {
            this.weaponData = weaponData;

            if (HoldingWeapon)
            {
                meshFilter.mesh = weaponData.mesh;
                meshRenderer.material = weaponData.material;
            }   
            else
            {
                meshFilter.mesh = null;
                meshRenderer.material = null;
            }
        }
    }
}
