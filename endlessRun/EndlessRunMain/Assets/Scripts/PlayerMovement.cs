using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    bool alive = true;
    public Animator anim;

    public float speed = 5;
    public float maxSpeed = 18f;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;                //dzięki temu gracz porusza się horyzontalnie (prawo, lewo) 2 raza szybciej niz porusza się do przodu

    public float speedIncreasePerPoint = 0.1f;

    //NEW MOVEMENT TRY

    private int desiredLane = 1;
    public float laneDistance = 2;
    private Vector3 direction;

    //END OF TRY

    public float boostTimer;
    public bool boosting;
    public float boostMoveTimer;
    public bool boostingMove;
    [SerializeField] private Renderer myObject;

    CapsuleCollider playerCollidor;
    float normalHeight;
    public float reducedHeight;
    private bool defaultMovement;

    public bool speedBooster;
    public bool invincibleBooster;
    public bool coinBooster;
    public bool movementSwapBooster;


    //END
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

        //NEW TRY
        if (!defaultMovement)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }
        }
        //NEW TRY END

        //NEW TRY EDITOR
        if (speedBooster)
        {
            boosting = true;
            if (speedBooster)
            {
                speedBooster = false;
                speed -= 5;
            }
        }
        if (invincibleBooster)
        {
            boostingMove = true;
            if (invincibleBooster)
            {
                invincibleBooster = false;
                anim.Play("Fox_Attack_TailUSE");
                this.gameObject.layer = 9;
            }
        }
        if (coinBooster)
        {
            coinBooster = false;
            GameManager.inst.IncrementDoubleScore();
        }
        if (movementSwapBooster)
        {
            movementSwapBooster = false;
            if (defaultMovement)
                {
                    defaultMovement = false;
                }
                else if (!defaultMovement)
                {
                    defaultMovement = true;
                }
        }
        //END
    }
    private void FixedUpdate ()
    {
        if (!alive) return;

        if(speed < maxSpeed)
            speed += 0.1f * Time.deltaTime;

        if (defaultMovement)
        {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;   //kliknięcie klawisza d powoduje przesuwanie gracza w prawo, a klawisza a - w lewo

            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }

        if (boosting == true)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                //speed = 10;
                speed += 5;
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

        //START TRY
        if (!defaultMovement)
        {
            rb.MovePosition(rb.position + direction * Time.deltaTime);
            direction.z = speed;

            Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
            {
                newPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                newPosition += Vector3.right * laneDistance;
            }

            transform.position = Vector3.Lerp(transform.position, newPosition, 80 * Time.deltaTime);
        }
        //END TRY

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            speed -= 5;
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
        if (other.tag == "swapMovement")
        {
            if (defaultMovement)
            {
                defaultMovement = false;
            }
            else if (!defaultMovement)
            {
                defaultMovement = true;
            }
        }
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
        defaultMovement = true;

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
