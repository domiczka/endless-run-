using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coinScore;
    public Text coinsText;

    public Text distanceText;
    public int distanceScore;
    
    public Transform player;
    public static GameManager inst;
    public PlayerMovement playerMovement;
    public GameObject GameOverMenu;

    private float boostTimer;
    private bool boosting;

    public void IncrementScore()
    {
        if (boosting)
        {
            coinScore++;
            coinScore++;
            coinsText.text = "Coins: " + coinScore;

            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                boostTimer = 0;
                boosting = false;
            }
        }
        else
        {
            coinScore++;
            coinsText.text = "Coins: " + coinScore;

            //player speed
            //playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }
    }

    private void Update()
    {
        distanceText.text = player.position.z.ToString("0");
        distanceScore = (int)player.position.z; 

    }

    public void IncrementDoubleScore()
    {
        boosting = true;
    }

    private void Awake ()
    {
        inst = this;
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        //Hier highscore speichern
        PlayerPrefs.SetInt("Distance" , distanceScore);
        PlayerPrefs.SetInt("Coins", coinScore);
    }
}
