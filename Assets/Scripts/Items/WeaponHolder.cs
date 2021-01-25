using DesertStormZombies.Entity;
using DesertStormZombies.Entity.Player;
using DesertStormZombies.Game;
using DesertStormZombies.Utility;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace DesertStormZombies.Items
{
    [RequireComponent(typeof(Animation))]
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private PointsHolder pointsHolder;
        [SerializeField] private GameStatistics gameStatistics;

        [Header("Weapon Modifier")]
        [SerializeField] private float damageModifier;
        [SerializeField] private float fireRateModifier;
        [SerializeField] private float reloadSpeedModifier;

        private WeaponData weaponData;
        private GameObject weaponModel;

        private Animation holderAnimation;

        private IntervalTimer fireRateTimer;

        private Ray ShotRay => new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        public bool SwitchingWeapon { get; private set; }

        public Animation ShootAnimation { get; private set; }

        private void Awake()
        {
            fireRateTimer = new IntervalTimer(0);

            holderAnimation = GetComponent<Animation>();
        }

        private void Update()
        {
            if (weaponData == null)
            {
                return;
            }

            fireRateTimer.Interval = weaponData.FireRate * fireRateModifier;

            if (Input.GetMouseButton(0) && fireRateTimer.Check(Time.deltaTime))
            {
                if (Physics.Raycast(ShotRay, out RaycastHit hit, 1000) && hit.collider.TryGetComponent(out Health health))
                {
                    pointsHolder += 10;

                    health.Reduce((uint)(weaponData.Damage * damageModifier));

                    if (health.isDepleted)
                    {
                        gameStatistics.AddKills(1);

                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        public void SetWeaponData(WeaponData weaponData)
        {
            this.weaponData = weaponData;

            if (weaponData != null)
            {
                holderAnimation.Play();

                StartCoroutine(ChangeWeapon());
            }
            else
            {
                Destroy(weaponModel);
            }
        }

        public void SetDamageModifier(float damageModifier) 
        { 
            this.damageModifier = damageModifier; 
        }
        public void SetFireRateModifier(float fireRateModifier) 
        {
            this.fireRateModifier = fireRateModifier; 
        }
        public void SetReloadSpeedModifier(float reloadSpeedModifier) 
        { 
            this.reloadSpeedModifier = reloadSpeedModifier; 
        }

        private IEnumerator ChangeWeapon()
        {
            SwitchingWeapon = true;

            yield return new WaitForSeconds(0.5f);

            InstantiateWeaponData();

            SwitchingWeapon = false;
        }

        private void InstantiateWeaponData()
        {
            Destroy(weaponModel);

            weaponModel = Instantiate(weaponData.Model, transform);

            ShootAnimation = weaponModel.GetComponent<Animation>();
        }
    }
}
