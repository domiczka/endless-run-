using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nowy_ground_tile_test : MonoBehaviour {
    public FrequencyInfo[] obstacles;

    GroundSpawner groundSpawner;
    public GameObject coinPrefab;
    public GameObject ObstaclePrefab;
    public GameObject movingObstacleRight;
    public GameObject movingObstacleLeft;
    public GameObject RollUnderObstaclePrefab;
    public GameObject SlideObstaclePrefab;


    private void Start() {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if(!SpawnMovingObstacle()) {
            //int i = Random.Range(0, 9);
            for(int x = 1; x < obstacles.Length; x++) {
                obstacles[x].probability += obstacles[x - 1].probability;
            }


            float totalProbs = Random.Range(0, obstacles[obstacles.Length - 1].probability);
            int j = 0;
            for(; j < obstacles.Length; j++) {
                if(totalProbs <= obstacles[j].probability) {
                    break;
                }
            }
            if(j == 0) {
                SpawnObstacle();
            } else if(j == 1) {
                SpawnRollUnderObstacle();
            } else if(j == 2) {
                SpawnSlideObstacle();
            }

        }
    }



    private void OnTriggerExit(Collider collision) {
        if(collision.gameObject.name == "Player") {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    void SpawnObstacle() {
        //old spawn
        //int obstacleSpawnIndex = Random.Range(2, 5);
        //Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        //trying new spawn logic below:
        Transform obstacleLeft = transform.GetChild(2).transform;
        Transform obstacleMiddle = transform.GetChild(3).transform;
        Transform obstacleRight = transform.GetChild(4).transform;

        int obstacleSpawnFormation = Random.Range(1, 8);
        if(obstacleSpawnFormation == 1) {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 2) {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 3) {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 4) {
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 5) {
            Instantiate(RollUnderObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 6) {
            Instantiate(RollUnderObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }
        if(obstacleSpawnFormation == 7) {
            Instantiate(ObstaclePrefab, obstacleLeft.position, Quaternion.identity, transform);
            Instantiate(RollUnderObstaclePrefab, obstacleMiddle.position, Quaternion.identity, transform);
            Instantiate(ObstaclePrefab, obstacleRight.position, Quaternion.identity, transform);
        }

    }
    bool SpawnMovingObstacle() {
        int spawnChance = Random.Range(1, 8);

        //int spawnSide = Random.Range(5, 7);
        int rightSpawnIndex = 5;
        int leftSpawnIndex = 6;

        Transform rightSpawnPoint = transform.GetChild(rightSpawnIndex).transform;
        Transform leftSpawnPoint = transform.GetChild(leftSpawnIndex).transform;

        if(spawnChance == 1) {
            Instantiate(movingObstacleRight, rightSpawnPoint.position, Quaternion.identity, transform);
            return true;
        }
        if(spawnChance == 2) {
            Instantiate(movingObstacleLeft, leftSpawnPoint.position, Quaternion.identity, transform);
            return true;
        }
        return false;
    }

    void SpawnRollUnderObstacle() {
        int rollUnderObstacleSpawnIndex = Random.Range(7, 10);
        Transform spawnPoint = transform.GetChild(rollUnderObstacleSpawnIndex).transform;

        Instantiate(RollUnderObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnSlideObstacle() {
        int slideObstacleSpawnIndex = Random.Range(10, 13);
        Transform spawnPoint = transform.GetChild(slideObstacleSpawnIndex).transform;

        Instantiate(SlideObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }


    Vector3 GetRandomPointInCollider(Collider collider) {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if(point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}





[System.Serializable]
public class FrequencyInfo {
    public GameObject spawnObject;
    public float probability;
    //public int minProbabilityRange = 0;
    //public int maxProbabilityRange = 0;
}

