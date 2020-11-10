using UnityEngine;

public class GroundTile : MonoBehaviour {

    public Transform spawnPoint;
    public Transform[] obstaclePoints;
    GroundSpawner groundSpawner;

    public GameObject coinPrefab;
    public GameObject ObstaclePrefab;

    private void Start() {
        groundSpawner = GroundSpawner.Instance;
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    private void Update() {

    }




    void SpawnCoins() {
        int coinsToSpawn = 10;
        for(int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
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

