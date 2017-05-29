using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Player.score = 0;
        Levels.level = 0;
        Scoring.pauseScoreDecay = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
		else if (Input.anyKey)
        {
            SceneManager.LoadScene("Level");
        }
	}
}
