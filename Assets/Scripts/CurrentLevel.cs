using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = Levels.level.ToString();
    }
}
