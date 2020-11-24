
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    bool alive = true; 

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;                //dzięki temu gracz porusza się horyzontalnie (prawo, lewo) 2 raza szybciej niz porusza się do przodu

    public float speedIncreasePerPoint = 0.1f;

    private float boostTimer;
    private bool boosting;

    CapsuleCollider playerCollidor;
    float normalHeight;
    public float reducedHeight;

   private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;   //kliknięcie klawisza d powoduje przesuwanie gracza w prawo, a klawisza a - w lewo
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (boosting == true)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                speed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            //is slower after the boost
            speed += 5;
            Destroy(other.gameObject);
        }
        if (other.tag == "Invincibility")
        {
            //disable collider but keep the movement?
        }
        if (other.tag == "CoinBoost")
        {
            GameManager.inst.IncrementDoubleScore();
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Crouch();
        if (Input.GetKeyUp(KeyCode.DownArrow))
            StopCrouch();

    }
    void Crouch()
    {
        playerCollidor.height = reducedHeight;
    }
    void StopCrouch()
    {
        playerCollidor.height = normalHeight;
    }

    public void Die ()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    public void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        boostTimer = 0;
        boosting = false;

        playerCollidor = GetComponent<CapsuleCollider>();
        normalHeight = playerCollidor.height;
    }
    void Restart()
    {
        Debug.Log("Test1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.GameOver();
    }
}
