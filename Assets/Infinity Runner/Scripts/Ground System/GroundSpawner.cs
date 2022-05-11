using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTilePrefab;
    Vector3 _nextSpawnPoint;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }

    internal void SpawnTile()
    {
        GameObject go = Instantiate(groundTilePrefab, _nextSpawnPoint, Quaternion.identity, transform);
        _nextSpawnPoint = go.transform.GetChild(1).transform.position;
    }


}
