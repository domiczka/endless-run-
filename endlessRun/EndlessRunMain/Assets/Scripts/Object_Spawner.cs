using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] coins;
    private float coinSpawnTimer = 7.0f;


    // Update is called once per frame
    void Update()
    {
        coinSpawnTimer -= coinSpawnTimer.deltaTime;

        if (coinSpawnTimer < 0.01)
        {
            SpawnCoins();
        }
    }

void SpawnCoins ()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(Random.Range(-2, 2), 0, player.transform.position.z + 30), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 3.0f);
    }

}
