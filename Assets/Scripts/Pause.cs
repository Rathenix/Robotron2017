using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseScreen;
    private GameObject _pauseScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            if (gameIsPaused)
            {
                _pauseScreen = Instantiate(pauseScreen, new Vector3(), new Quaternion(), GetComponent<Canvas>().transform);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                Destroy(_pauseScreen);
            }
        }
	}
}
