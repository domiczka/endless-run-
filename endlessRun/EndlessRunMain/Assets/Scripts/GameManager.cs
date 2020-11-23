using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public Text scoreText;
    public GameObject GameOverMenu;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
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
