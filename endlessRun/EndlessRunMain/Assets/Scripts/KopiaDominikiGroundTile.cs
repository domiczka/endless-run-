using UnityEngine;

public class KopiaDominikiGroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnRollUnderObstacle();

    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    private void Update()
    {

    }
    public GameObject ObstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;


        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }

    public GameObject RollUnderObstaclePrefab;

    void SpawnRollUnderObstacle()
    {
        int rollUnderObstacleSpawnIndex = Random.Range(7, 10);
        Transform spawnPoint = transform.GetChild(rollUnderObstacleSpawnIndex).transform;

        Instantiate(RollUnderObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }


    public GameObject coinPrefab;


    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
