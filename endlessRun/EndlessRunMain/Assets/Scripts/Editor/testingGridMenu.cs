using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testingGridMenu : EditorWindow 
{
    bool groupEnabled;
    //bool demoMode = false;
    bool jumpObstacle = true;
    bool slideObstacle = true;
    bool evadeObstacle = true;
    bool movingObstacleLeft = true;
    bool movingObstacleRight = true;
    public GameObject pfEvadeObstacle;
    public GameObject pfJumpObstacle;
    public GameObject pfSlidingObstacle;
    public GameObject pfMovingObstacleLeft;
    public GameObject pfMovingObstacleRight;

    // Add menu named "My Window" to the Window menu
    [MenuItem("My Tools/TestingGrid")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        testingGridMenu window = (testingGridMenu)EditorWindow.GetWindow(typeof(testingGridMenu));
        window.Show();
    }
    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        //demoMode = EditorGUILayout.Toggle("Activate Demo Mode", demoMode);

        //myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Exclude ObstacleTyp Settings", groupEnabled);
        evadeObstacle = EditorGUILayout.Toggle("Active EvadeObstacle", evadeObstacle);
        jumpObstacle = EditorGUILayout.Toggle("Active JumpObstacle", jumpObstacle);
        slideObstacle = EditorGUILayout.Toggle("Active SlideObstacle", slideObstacle);
        movingObstacleLeft = EditorGUILayout.Toggle("Active MovingObstacle", movingObstacleLeft);
        movingObstacleRight = EditorGUILayout.Toggle("Active MovingObstacle", movingObstacleRight);
        EditorGUILayout.EndToggleGroup();

        //if (GUILayout.Button("Disable Camera"))
        //{
            //var gameObj = GameObject.Find("TorriPre");
            //gameObj.SetActive(false);
        //}

        pfEvadeObstacle.SetActive(evadeObstacle);
        pfJumpObstacle.SetActive(jumpObstacle);
        pfSlidingObstacle.SetActive(slideObstacle);
        pfMovingObstacleLeft.SetActive(movingObstacleLeft);
        pfMovingObstacleRight.SetActive(movingObstacleRight);
    }
}
