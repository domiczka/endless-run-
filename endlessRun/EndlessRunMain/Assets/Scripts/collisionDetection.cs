using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public GroundTile groundTile;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {

            int speedRight = Random.Range(-4, -11);
            int speedLeft = Random.Range(4, 11);

            if (gameObject.name == "SmallRockLeft")
            {
                GetComponent<ConstantForce>().force = new Vector3(speedLeft, 0, 0);
            }
            if (gameObject.name == "SmallRockRight")
            {
                GetComponent<ConstantForce>().force = new Vector3(speedRight, 0, 0);
            }

            GetComponent<ConstantForce>().enabled = true;

        }
    }
}
