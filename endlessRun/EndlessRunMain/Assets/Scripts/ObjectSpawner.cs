using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] coins;
    private float coinSpawnTimer = 1.0f;


    // Update is called once per frame
    void Update()
    {
        coinSpawnTimer -= Time.deltaTime;

        if (coinSpawnTimer < 0.01)
        {
            SpawnCoins();
        }
    }

void SpawnCoins ()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(Random.Range(-3, 3), 1, player.transform.position.z + 91), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 2.0f);
    }

}
