using UnityEngine;

using FPSControllerLPFP;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private EnemyAI[] enemyPrefabs;
    [SerializeField] private FpsControllerLPFP playerController;

    [Header("Settings")]
    [SerializeField] private uint minSpawn;
    [SerializeField] private uint maxSpawn;

    [SerializeField] private float width;
    [SerializeField] private float depth;
    [SerializeField] private float spawnRate;

    private void Start()
    {
        StartCoroutine(SpawnZombiesRoutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = RotationMatrix;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, 0, depth));
    }

    private void SpawnZombies()
    {
        int zombies = Random.Range((int)minSpawn, (int)maxSpawn);

        for (int i = 0; i < zombies; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(width / 2, width / 2), 0, Random.Range(depth / 2, depth / 2));

            EnemyAI enemy = Instantiate(RandomEnemy);

            enemy.setTarget(playerController);
            enemy.transform.position = RotationMatrix.MultiplyVector(randomPosition) + transform.position;
        }
    }
    private IEnumerator SpawnZombiesRoutine()
    {
        while (isActiveAndEnabled)
        {
            SpawnZombies();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private EnemyAI RandomEnemy => enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

    private Matrix4x4 RotationMatrix => Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
}