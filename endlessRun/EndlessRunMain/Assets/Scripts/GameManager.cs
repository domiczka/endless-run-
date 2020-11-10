using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int score;
    public static GameManager inst { get; private set; } //Instance
    public Text scoreText;

    public void IncrementScore() {
        score++;
        scoreText.text = "Score: " + score;
    }

    private void Awake() {
        if(inst != null) {
            Destroy(this.gameObject);
        }
        inst = this;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
