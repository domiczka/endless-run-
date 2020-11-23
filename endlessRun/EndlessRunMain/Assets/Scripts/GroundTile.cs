using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    GroundSpawner groundSpawner;
    public GameObject coinPrefab;
    public GameObject ObstaclePrefab;
    public GameObject movingObstacle;
    public GameObject RollUnderObstaclePrefab;
    public GameObject SlideObstaclePrefab;


    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (!SpawnMovingObstacle())
        {
            SpawnObstacle();
            SpawnRollUnderObstacle();
            SpawnSlideObstacle();
        }


    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    private void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;


        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    bool SpawnMovingObstacle()
    {
       //makes the game lag on launch for whatever reason
        int spawnChance = Random.Range(1, 6);

        int rightSpawnIndex = 5;
        int leftSpawnIndex = 6;

        Transform rightSpawnPoint = transform.GetChild(rightSpawnIndex).transform;
        Transform leftSpawnPoint = transform.GetChild(leftSpawnIndex).transform;

        //makes the game lag on launch for whatever reason + some tiles despawn after the obstacle moves
        if (spawnChance == 1)
        {
            Instantiate(movingObstacle, rightSpawnPoint.position, Quaternion.identity, transform);
            return true;
        } 
        return false;
    }

    void SpawnRollUnderObstacle()
    {
        int rollUnderObstacleSpawnIndex = Random.Range(7, 10);
        Transform spawnPoint = transform.GetChild(rollUnderObstacleSpawnIndex).transform;

        Instantiate(RollUnderObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnSlideObstacle()
    {
        int slideObstacleSpawnIndex = Random.Range(10, 13);
        Transform spawnPoint = transform.GetChild(slideObstacleSpawnIndex).transform;

        Instantiate(SlideObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }


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

