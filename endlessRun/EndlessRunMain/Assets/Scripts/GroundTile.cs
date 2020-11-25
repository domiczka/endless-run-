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
            int spawnChance = Random.Range(1, 7);

            if (spawnChance == 1 || spawnChance == 2 || spawnChance == 3)
            {
                SpawnObstacle();
            }
            if (spawnChance == 4 || spawnChance == 5)
            {
                SpawnRollUnderObstacle();
            }
            if (spawnChance == 6)
            {
                SpawnSlideObstacle();
            }
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

    void SpawnObstacle()
    {
        //old spawn
        //int obstacleSpawnIndex = Random.Range(2, 5);
        //Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        //trying new spawn logic below:
        Transform obstacleLeft = transform.GetChild(2).transform;
        Transform obstacleMiddle = transform.GetChild(3).transform;
        Transform obstacleRight = transform.GetChild(4).transform;

        int obstacleSpawnFormation = Random.Range(1, 8);
        if (obstacleSpawnFormation == 1)
        {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 2)
        {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 3)
        {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 4)
        {
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 5)
        {
            Instantiate(RollUnderObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 6)
        {
            Instantiate(RollUnderObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnFormation == 7)
        {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }

    }
    bool SpawnMovingObstacle()
    {
        int spawnChance = Random.Range(1, 6);

        //int spawnSide = Random.Range(5, 7);
        int rightSpawnIndex = 5;
        int leftSpawnIndex = 6;

        Transform rightSpawnPoint = transform.GetChild(rightSpawnIndex).transform;
        Transform leftSpawnPoint = transform.GetChild(leftSpawnIndex).transform;

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

