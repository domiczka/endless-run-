using UnityEditor;
using UnityEngine;
using System.Collections;

public class prefabCreationWindow : EditorWindow
{
    public GameObject obj = null;
    [MenuItem("My Tools/PrefabCreationWindow")]
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(prefabCreationWindow));
        window.position = new Rect(650, 450, 450, 350);
        window.Show();
    }

    void OnInspectorUpdate()
    {
        Repaint();
    } 

    void OnGUI()
    {
        obj = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "Select desired object", obj, typeof(GameObject), false);

        if (GUI.Button(new Rect(3, 25, position.width - 6, 20), "Change Object into ObstaclePrefab"))
        {
            //8 = obstacle layer
            obj.layer = 8;
            obj.tag = "temp";
            obj.AddComponent<Obstacle>();
            obj.AddComponent<BoxCollider>();

            //PrefabUtility.InstantiatePrefab(obj);
        }
    }
}
