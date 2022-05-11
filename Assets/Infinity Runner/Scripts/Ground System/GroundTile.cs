using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameData gameData;
    GroundSpawner _groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject coinPrefab;

    void Start()
    {
        _groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        int obstacleSpawnIndex = Random.Range(2, 5);
        if (Random.value < gameData._tallObstacleChance)
        {
            obstacleSpawnIndex = 3;
            obstacleToSpawn = tallObstaclePrefab;
        }

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        if (transform.position.z > gameData._freeAreaDist)
            Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnCoins()
    {
        int coinToSpawn = gameData._coinPerTile;
        for (int i = 0; i < coinToSpawn; i++)
        {
            if (transform.position.z > gameData._freeAreaDist)
            {
                GameObject go = Instantiate(coinPrefab, transform);
                go.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            }
        }
    }

    Vector3 GetRandomPointInCollider(Collider col)
    {
        Vector3 point = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x), 1, Random.Range(col.bounds.min.z, col.bounds.max.z)
            );
        if (point != col.ClosestPoint(point)) point = GetRandomPointInCollider(col);
        return point;
    }
}
