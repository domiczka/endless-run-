using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public float turnSpeed = 90f;                    // szybkość obracania monety  
    
    void OnTriggerEnter (Collider other)

    {
        // sprawdzamy czy colliderem jest gracz
        if (other.gameObject.name != "Player")  
        {
            return;                                  //tzn jeśli colliderem nie jest gracz to zatrzymujemy funkcję
        }


        //dodajemy punkt (za zebranie monety)

        //niszczymy monetę
        Destroy(gameObject);

    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);   //obracanie monety
    }
}
