using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public Text scoreText;
    public PlayerMovement playerMovement;
    public GameObject GameOverMenu;

    private float boostTimer;
    private bool boosting;

    public void IncrementScore()
    {
        if (boosting)
        {
            score++;
            score++;
            scoreText.text = "Score: " + score;

            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                boostTimer = 0;
                boosting = false;
            }
        }
        else
        {
            score++;
            scoreText.text = "Score: " + score;

            //zwiększanie prędkości gracza:
            playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }

    }
    public void IncrementDoubleScore()
    {
        boosting = true;
    }


    private void Awake ()
    {
        inst = this;
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Debug.Log("Test");
    }
}
