using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

	// Use this for initialization
	void Start () {
        var enemies = 3 + Levels.level;
        for (var i = 0; i < enemies; i++)
        {
            var randx = Random.Range(-4.4f, 4.2f);
            var randy = Random.Range(-3.1f, 2.7f);
            var newEnemyObj = Instantiate(enemy, new Vector3(randx, randy, 0), new Quaternion(), transform);
            var newEnemy = newEnemyObj.GetComponent<Enemy>();
            newEnemy.player = player;
            var statDelta = Levels.level * 0.01f;
            if (Levels.level % 2 == 0)
            {
                if (newEnemy.moveCooldown >= statDelta)
                {
                    newEnemy.moveCooldown -= (Levels.level * 0.01f);
                }
                else
                {
                    newEnemy.moveCooldown = 0;
                }
            }
            if (Levels.level % 3 == 0)
            {
                if (newEnemy.shotCooldown >= statDelta)
                {
                    newEnemy.shotCooldown -= (Levels.level * 0.01f);
                }
                else
                {
                    newEnemy.shotCooldown = 0;
                }
            }
        }
        Scoring.pauseScoreDecay = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentsInChildren<Enemy>().Length == 0)
        {
            SceneManager.LoadScene("Level");
        }
        else if (GetComponentsInChildren<Player>().Length == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
	}
}
