using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    bool alive = true;
    public Animator anim;

    public float speed = 10;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;                //dzięki temu gracz porusza się horyzontalnie (prawo, lewo) 2 raza szybciej niz porusza się do przodu

    public float speedIncreasePerPoint = 0.1f;

    private float boostTimer;
    private bool boosting;
    private float boostMoveTimer;
    private bool boostingMove;
    [SerializeField] private Renderer myObject;

    CapsuleCollider playerCollidor;
    float normalHeight;
    public float reducedHeight;

    //TODO:
    //More rules for random obstacle spawn
    //Moving obstacles decide what way they go
    
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
                //speed = 10;
                speed -= 5;
                boostTimer = 0;
                boosting = false;
            }
        }
        if (boostingMove == true)
        {
            boostMoveTimer += Time.deltaTime;
            if (boostMoveTimer >= 5)
            {
                this.gameObject.layer = 10;
                anim.Play("Fox_RunUSE");
                //myObject.material.color = Color.blue;
                boostMoveTimer = 0;
                boostingMove = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            speed += 5;
            Destroy(other.gameObject);
        }
        if (other.tag == "Invincibility")
        {

            anim.Play("Fox_Attack_TailUSE");

            this.gameObject.layer = 9;
            //myObject.material.color = Color.green;
            boostingMove = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "CoinBoost")
        {
            GameManager.inst.IncrementDoubleScore();
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -8)
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
        anim.Play("Fox_SomersaultUSE");
    }
    void StopCrouch()
    {
        playerCollidor.height = normalHeight;
        anim.Play("Fox_RunUSE");
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

        anim = GetComponent<Animator>();
    }
    void Restart()
    {
        //Debug.Log("Test1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.GameOver();
    }
}
