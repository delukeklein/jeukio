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
        foreach (EnemyAI enemyPrefab in enemyPrefabs)
        {
            enemyPrefab.setTarget(playerController);
        }

        StartCoroutine(SpawnZombiesRoutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 0f, depth));
    }

    private void SpawnZombies()
    {
        Debug.LogError("NEEF");
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
