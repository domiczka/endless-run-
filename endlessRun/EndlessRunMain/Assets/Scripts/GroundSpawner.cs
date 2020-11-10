using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    public static GroundSpawner Instance { get; private set; }
    public GameObject groundTile;

    public GameObject coinPrefab;
    public GameObject ObstaclePrefab;

    Vector3 nextSpawnPoint;

    private void Awake() {
        if(Instance != null) {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start() {
        for(int i = 0; i < 15; i++) {
            SpawnTile();
        }
    }

    public void SpawnTile() {
        GroundTile temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity).GetComponent<GroundTile>();
        nextSpawnPoint = temp.spawnPoint.position;
        SpawnObstacle(temp);
    }

    void SpawnObstacle(GroundTile tile) {
        int obstacleSpawnIndex = Random.Range(0, tile.obstaclePoints.Length);
        Transform ob = tile.obstaclePoints[obstacleSpawnIndex];

        Instantiate(ObstaclePrefab, ob.position, Quaternion.identity, tile.transform);
    }


}