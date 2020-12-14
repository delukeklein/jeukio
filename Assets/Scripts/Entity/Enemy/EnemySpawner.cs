using UnityEngine;


using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private EnemyAI[] enemyPrefabs;
    [SerializeField] private FpsControllerLPFP playerController;

    [Header("Settings")]
    [SerializeField] private uint minSpawn;
    [SerializeField] private uint maxSpawn;

    [SerializeField] private float detectionRadius;
    [SerializeField] private float width;
    [SerializeField] private float depth;
    [SerializeField] private float spawnRate;

    public bool IsPlayerInRange { get; private set; }

    private void Start()
    {
        StartCoroutine(SpawnZombiesRoutine());
    }

    private void Update()
    {
        IsPlayerInRange = Vector3.Distance(transform.position, playerController.transform.position) <= detectionRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = RotationMatrix;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, 0, depth));

        Gizmos.color = new Color(0f, 1f, 0f, 0.33f);
        Gizmos.DrawSphere(Vector3.zero, detectionRadius);
    }

    private void SpawnZombies()
    {
        int zombies = Random.Range((int)minSpawn, (int)maxSpawn);

        for (int i = 0; i < zombies; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-width / 2, width / 2), 0, Random.Range(-depth / 2, depth / 2));

            EnemyAI enemy = Instantiate(RandomEnemy);

            enemy.setTarget(playerController);
            enemy.transform.position = RotationMatrix.MultiplyVector(randomPosition) + transform.position;
        }
    }
    private IEnumerator SpawnZombiesRoutine()
    {
        while(true)
        {
            if (IsPlayerInRange)
            {
                SpawnZombies();
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private EnemyAI RandomEnemy => enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

    private Matrix4x4 RotationMatrix => Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
}