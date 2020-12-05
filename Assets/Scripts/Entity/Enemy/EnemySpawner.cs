using UnityEngine;

using FPSControllerLPFP;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private EnemyAI[] enemyPrefabs;
    [SerializeField] private FpsControllerLPFP playerController;

    [Header("Settings")]
    [SerializeField] private int minSpawn;
    [SerializeField] private int maxSpawn;

    [SerializeField] private float width;
    [SerializeField] private float depth;
    [SerializeField] private float spawnRate;

    public bool IsEnabled { get; set; } = true;

    private void Start()
    {
        StartCoroutine(SpawnZombiesRoutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, transform.position.y, depth));
    }

    private void SpawnZombies()
    {
        int zombies = Random.Range(minSpawn, maxSpawn);

        for (int i = 0; i < zombies; i++)
        {
            float x = Random.Range(transform.position.x - width / 2, transform.position.x + width / 2);
            float z = Random.Range(transform.position.z - depth / 2, transform.position.z + depth / 2);

            int enemyIndex = Random.Range(0, enemyPrefabs.Length);

            EnemyAI enemy = Instantiate(enemyPrefabs[enemyIndex]);
            enemy.setTarget(playerController);

            enemy.transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    private IEnumerator SpawnZombiesRoutine()
    {
        while (IsEnabled)
        {
            SpawnZombies();

            yield return new WaitForSeconds(spawnRate);
        }
    }
}