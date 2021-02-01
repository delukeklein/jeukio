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
        [SerializeField] public float damageModifier;
        [SerializeField] public float fireRateModifier;
        [SerializeField] public float reloadSpeedModifier;

        [Header("Muzzle Flash")]
        [SerializeField] private int minSparkEmission = 1;
        [SerializeField] private int maxSparkEmission = 7;

        [SerializeField] private float lightDuration = 0.02f;

        [SerializeField] private Light muzzleflashLight;

        [SerializeField] private ParticleSystem muzzleParticles;
        [SerializeField] private ParticleSystem sparkParticles;

        [SerializeField] private AudioSource audioSource;

        [SerializeField] private TMPro.TextMeshProUGUI ammoText;

        private bool reloading;

        [SerializeField] public int Reserves;
        [SerializeField] public int currentBullets;

        private WeaponData weaponData;
        private GameObject weaponModel;

        private Animation holderAnimation;

        private IntervalTimerContinues fireRateTimer;

        private Ray ShotRay => new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        public bool SwitchingWeapon { get; private set; }

        public Animator ShootAnimator { get; private set; }

        private void Awake()
        {
            fireRateTimer = new IntervalTimerContinues(0);

            holderAnimation = GetComponent<Animation>();
        }

        private void Update()
        {
            ammoText.text = currentBullets + "/" + Reserves;

            fireRateTimer.Add(Time.deltaTime);

            if (weaponData == null || reloading || SwitchingWeapon)
            {
                return;
            }

            if (weaponData.Semi)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
            else
            {
                fireRateTimer.Interval = weaponData.FireRate / fireRateModifier;

                if (Input.GetMouseButton(0) && fireRateTimer.Check())
                {
                    Shoot();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }

        public void SetDamageModifier(float damageModifier) => this.damageModifier = damageModifier;
        public void SetFireRateModifier(float fireRateModifier) => this.fireRateModifier = fireRateModifier;
        public void SetReloadSpeedModifier(float reloadSpeedModifier) => this.reloadSpeedModifier = reloadSpeedModifier;

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

        private void Shoot()
        {
            if (!weaponData.Knife)
            {
                if (currentBullets <= 0)
                {
                    return;
                }

                currentBullets--;
            }

            if (ShootAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                ShootAnimator.Play("Shoot", -1, 0f);
            }

            audioSource.clip = weaponData.ShootAudio;
            audioSource.Play();

            if (weaponData.UseMuzzleFlash)
            {
                sparkParticles.Emit(Random.Range(minSparkEmission, maxSparkEmission));

                muzzleParticles.Emit(1);

                StartCoroutine(MuzzleFlashLight());
            }

            if (Physics.Raycast(ShotRay, out RaycastHit hit, weaponData.ShootDistance) && hit.collider.TryGetComponent(out Health health))
            {
                var enemy = health.GetComponent<EnemyAI>();
                enemy.BloodParticle.Play();

                health.Reduce((uint)(weaponData.Damage * damageModifier));

                if (health.isDepleted)
                {
                    enemy.ExplodeParticle.Play();

                    pointsHolder += 10;
                    gameStatistics.Kills++;

                    Destroy(hit.collider.gameObject);
                }
            }
        }

        private void ReloadAmmo()
        {
            int bulletsToAdd = weaponData.MagSize - currentBullets;

            currentBullets += Mathf.Clamp(bulletsToAdd, 0, Reserves);
            Reserves -= Mathf.Clamp(bulletsToAdd, 0, Reserves);
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

            ShootAnimator = weaponModel.GetComponent<Animator>();
        }

        private IEnumerator MuzzleFlashLight()
        {
            muzzleflashLight.enabled = true;

            yield return new WaitForSeconds(lightDuration);

            muzzleflashLight.enabled = false;
        }

        private IEnumerator Reload()
        {
            reloading = true;

            holderAnimation.Play();

            audioSource.clip = weaponData.ReloadAudio;
            audioSource.Play();

            yield return new WaitForSeconds(weaponData.ReloadSpeed / reloadSpeedModifier);

            ReloadAmmo();

            reloading = false;
        }
    }
}
