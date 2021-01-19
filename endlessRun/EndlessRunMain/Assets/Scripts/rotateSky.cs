using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSky : MonoBehaviour
{
    public float rSpeed = 1.2f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rSpeed);   
    }

}
