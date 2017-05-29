using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public static int highScore;

    // Use this for initialization
    void Start () {
        var scoreStr = File.ReadAllText(@"highscores.txt");
        highScore = Convert.ToInt32(scoreStr);
        GetComponent<TextMeshProUGUI>().text = scoreStr;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
