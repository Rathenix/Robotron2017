using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

    public static int level = 0;
    private float loadTime;
    private float loadDelay = 2;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        Scoring.pauseScoreDecay = true;
        level++;
        loadTime = Time.time;
        var levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = level.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= loadTime + loadDelay)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
