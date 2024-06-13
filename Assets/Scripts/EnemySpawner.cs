using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnArea; 
    public float spawnInterval = 5f;
    public float yOffset = 1f; 

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnAreaSize = spawnArea.transform.localScale * 10; 
        Vector3 spawnAreaPosition = spawnArea.transform.position;

        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaPosition.x - spawnAreaSize.x / 2, spawnAreaPosition.x + spawnAreaSize.x / 2),
            spawnAreaPosition.y + yOffset, 
            Random.Range(spawnAreaPosition.z - spawnAreaSize.z / 2, spawnAreaPosition.z + spawnAreaSize.z / 2)
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
