using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI hsDistance;
    public TextMeshProUGUI hsCoins;
    // Start is called before the first frame update
    void Start()
    {
        hsDistance.text = "Distance:" + PlayerPrefs.GetInt("Distance", 0).ToString();
        hsCoins.text = "Coins:" + PlayerPrefs.GetInt("Coins", 0).ToString();
    }

}
