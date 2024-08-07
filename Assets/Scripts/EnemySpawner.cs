using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnArea; 
    public float spawnInterval = 5f;
    public float yOffset = 1f;
    public Transform[] waypoints;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(-2.57f, 0.6282701f, 27.88f);
        enemyPrefab.GetComponent<EnemyMovement>().waypoints = waypoints;

        Instantiate(enemyPrefab, spawnPosition, new Quaternion(0f,-180f,0f,0f));
    }
}
