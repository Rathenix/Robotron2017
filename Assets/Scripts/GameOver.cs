using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private float loadTime;
    private float loadDelay = 2;

    // Use this for initialization
    void Start () {
        Scoring.pauseScoreDecay = true;
        loadTime = Time.time;
        if (Player.score > HighScore.highScore)
        {
            File.WriteAllText(@"highscores.txt", Player.score.ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > loadTime + loadDelay)
        {
            var instructions = GetComponent<TextMeshProUGUI>();
            instructions.color = Color.white;
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
