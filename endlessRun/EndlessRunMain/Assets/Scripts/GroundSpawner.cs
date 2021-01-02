using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public GameObject groundTileEmpty;
    Vector3 nextSpawnPoint;
    bool emptyTiles = true;


    public void SpawnTile()
    {
        if (emptyTiles == true)
        {
            //Debug.Log("EMPTY TRUE ONCE");
            GameObject temp = Instantiate(groundTileEmpty, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            emptyTiles = false;
        }
        else
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
                SpawnTile();
        }
    }
}