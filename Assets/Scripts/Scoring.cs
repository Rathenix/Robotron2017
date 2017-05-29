using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour {

    private float lastDeduct;
    private float deductRate = 1f;
    public int scoreDecayAmount = 5;
    public static bool pauseScoreDecay = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!pauseScoreDecay && Time.time >= lastDeduct + deductRate && Player.score >= scoreDecayAmount)
        {
            Player.score -= scoreDecayAmount;
            lastDeduct = Time.time;
        }

        var scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = Player.score.ToString();
	}
}