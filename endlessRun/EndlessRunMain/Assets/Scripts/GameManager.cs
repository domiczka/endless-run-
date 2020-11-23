using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        //zwiększenie prędkości gracza 
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
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
}
