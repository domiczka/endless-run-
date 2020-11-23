using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObjects : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("temp"))
        {
            Debug.Log("Test123");
            Destroy(other.gameObject, 2);
        }
    }
}
