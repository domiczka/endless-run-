using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject hsMenu;
    private bool hsMenuOn = false;
    public void StartGame ()
    {
        SceneManager.LoadScene("endless run 1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void HighScoreMenu()
    {
        if (!hsMenuOn)
        {
            hsMenu.SetActive(true);
            hsMenuOn = true;
        }
        else if (hsMenuOn)
        {
            hsMenu.SetActive(false);
            hsMenuOn = false;
        }
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
