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

    public float evadeObstacleFrequency = 5.0f;
    public float jumpObstacleFrequency = 5.0f;
    public float slideObstacleFrequency = 5.0f;
    public float movingObstacleLeftFrequency = 5.0f;
    public float movingObstacleRightFrequency = 5.0f;

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
        evadeObstacleFrequency = EditorGUILayout.FloatField("Evade obstacle frequency", evadeObstacleFrequency);


        jumpObstacle = EditorGUILayout.Toggle("Active JumpObstacle", jumpObstacle);
        jumpObstacleFrequency = EditorGUILayout.FloatField("Jump obstacle frequency", jumpObstacleFrequency);
        
        slideObstacle = EditorGUILayout.Toggle("Active SlideObstacle", slideObstacle);
        slideObstacleFrequency = EditorGUILayout.FloatField("Slide obstacle frequency", slideObstacleFrequency);
        
        movingObstacleLeft = EditorGUILayout.Toggle("Active MovingObstacle", movingObstacleLeft);
        movingObstacleLeftFrequency = EditorGUILayout.FloatField("Moving obstacle left frequency", movingObstacleLeftFrequency);

        movingObstacleRight = EditorGUILayout.Toggle("Active MovingObstacle", movingObstacleRight);
        movingObstacleRightFrequency = EditorGUILayout.FloatField("Moving obstacle right frequency", movingObstacleRightFrequency);

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


