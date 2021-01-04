using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float coinSpawnTimer = 1.0f;
    public GameObject player;
    public GameObject[] coins;

    public float boosterSpawnTimer = 15.0f;
    public GameObject[] booster;

    // Update is called once per frame
    void Update()
    {
        coinSpawnTimer -= Time.deltaTime;
        boosterSpawnTimer -= Time.deltaTime;

        if (coinSpawnTimer < 0.01)
        {
            SpawnCoins();
        }
        if (boosterSpawnTimer < 0.01)
        {
            SpawnBooster();
        }
    }

    void SpawnCoins ()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(Random.Range(-3, 3), 1, player.transform.position.z + 91), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 2.0f);
        //Debug.Log("Spawn Coins");
    }
    void SpawnBooster()
    {
        //Debug.Log("Spawn Booster");
        Instantiate(booster[(Random.Range(0, booster.Length))], new Vector3(Random.Range(-3, 3), 1, player.transform.position.z + 91), Quaternion.identity);
        boosterSpawnTimer = Random.Range(1.0f, 3.0f);
    }

}
