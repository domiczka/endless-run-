
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;                //dzięki temu gracz porusza się horyzontalnie (prawo, lewo) 2 raza szybciej niz porusza się do przodu


   private void FixedUpdate ()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;   //kliknięcie klawisza d powoduje przesuwanie gracza w prawo, a klawisza a - w lewo
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }



    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
