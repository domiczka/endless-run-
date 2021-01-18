using UnityEditor;
using UnityEngine;

public class BasicObjectSpawner : EditorWindow
{
    int objectID = 1;
    GameObject objectToSpawn;
    float Distance = 5f;
    public int yPosition = 0;

    [MenuItem("Tools/Basic ObjectSpawner")]
    public  static void ShowWindow()
    {
        GetWindow(typeof(BasicObjectSpawner));
    }

    private void  OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

        objectID = EditorGUILayout.IntField("Object ID", objectID);
        yPosition = EditorGUILayout.IntField("yPosition", yPosition);
        Distance = EditorGUILayout.FloatField("Distance", Distance);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        if(objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
            return;
        }

        int spawnPointX = Random.Range(1, 7);
        int spawnPointY = yPosition;
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);

        for (int i = 0; i < objectID; i++)
        {
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }

    }


}
