using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpSpeed = 8;
    public float fallSpeed = 1.5f;
    private Rigidbody rigidBody;
    private bool onGround = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && onGround)
        {
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            if (onGround == false)
            {
                Invoke("MoveDown", 0.5f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    public void MoveDown()
    {
        rigidBody.AddForce(Vector3.down * fallSpeed, ForceMode.Impulse);
    }
}
