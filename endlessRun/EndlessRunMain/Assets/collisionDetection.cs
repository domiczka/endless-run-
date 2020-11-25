using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public GroundTile groundTile;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //ask which spawn index do another if with constant force for each side
            //if (spawnSide == 5)
            //then move to the right
            
            //if (spwnSide == 6)
            //then move to the left

            GetComponent<ConstantForce>().enabled = true;

        }
    }
}
