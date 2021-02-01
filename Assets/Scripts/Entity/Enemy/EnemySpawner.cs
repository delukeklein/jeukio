using DesertStormZombies.Utility;

using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Random;

namespace DesertStormZombies.Entity.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Refrences")]
        [SerializeField] private EnemyAI[] enemyPrefabs;
        [SerializeField] private PlayerMovement player;

        [Header("Settings")]
        [SerializeField] private uint minSpawn;
        [SerializeField] private uint maxSpawn;

        [SerializeField] private float detectionRadius;
        [SerializeField] private float width;
        [SerializeField] private float depth;
        [SerializeField] private float spawnRate;

        private IntervalTimer timer;

        public bool IsPlayerInRange { get; private set; }

        private int RandomSpawnAmount => Range((int)minSpawn, (int)maxSpawn);

        private Vector3 RandomSpawnPosition => new Vector3(Range(-width / 2f, width / 2f), 0, Range(-depth / 2f, depth / 2f));

        private EnemyAI RandomEnemy => enemyPrefabs[Range(0, enemyPrefabs.Length)];

        private void Start()
        {
            timer = new IntervalTimer(spawnRate);
        }

        private void Update()
        {
            IsPlayerInRange = Vector3.Distance(transform.position, player.transform.position) <= detectionRadius;

            if (IsPlayerInRange && timer.Check(Time.deltaTime))
            {
                SpawnZombies();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, 0, depth));

            Gizmos.color = new Color(0f, 1f, 0f, 0.33f);
            Gizmos.DrawSphere(Vector3.zero, detectionRadius);
        }

        private void SpawnZombies()
        {
            for (int i = 0; i < RandomSpawnAmount; i++)
            {
                var enemy = Instantiate(RandomEnemy);
                var navMeshAgent = enemy.GetComponent<NavMeshAgent>();

                var position = transform.localToWorldMatrix.MultiplyVector(RandomSpawnPosition) + transform.position;

                enemy.setTarget(player);

                navMeshAgent.enabled = false;

                enemy.transform.position = position;

                navMeshAgent.enabled = true;

                print(position);
            }
        }
    }
}