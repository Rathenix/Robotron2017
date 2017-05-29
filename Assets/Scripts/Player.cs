using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int score = 0;
    public float speed = 10;
    private float _trueSpeed;
    public int health = 1;
    public float shotCooldown = 0.25f;
    private float spawnTime;
    public float invulTime = 1;
    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();
    public GameObject horizontalBullet;
    public GameObject verticalBullet;
    private float shotTime;
    public AudioClip shotSound;
    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
        spawnTime = Time.time;
        _trueSpeed = speed * 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        
		if (Input.GetKey(KeyCode.W) && transform.position.y <= topBounds.y && !Pause.gameIsPaused)
        {
            transform.position += new Vector3(0, _trueSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= bottomBounds.y && !Pause.gameIsPaused)
        {
            transform.position += new Vector3(0, -_trueSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= bottomBounds.x && !Pause.gameIsPaused)
        {
            transform.position += new Vector3(_trueSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= topBounds.x && !Pause.gameIsPaused)
        {
            transform.position += new Vector3(-_trueSpeed, 0, 0);
        }

        if (Time.time >= shotTime + shotCooldown)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Pause.gameIsPaused)
            {
                var shot = Instantiate(verticalBullet, transform.position, new Quaternion());
                shot.GetComponent<Bullet>().source = gameObject;
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                StartCoroutine("ShotSound");
                shotTime = Time.time;
            }
            if (Input.GetKey(KeyCode.DownArrow) && !Pause.gameIsPaused)
            {
                var shot = Instantiate(verticalBullet, transform.position, new Quaternion());
                shot.GetComponent<Bullet>().source = gameObject;
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                StartCoroutine("ShotSound");
                shotTime = Time.time;
            }
            if (Input.GetKey(KeyCode.RightArrow) && !Pause.gameIsPaused)
            {
                var shot = Instantiate(horizontalBullet, transform.position, new Quaternion());
                shot.GetComponent<Bullet>().source = gameObject;
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                StartCoroutine("ShotSound");
                shotTime = Time.time;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !Pause.gameIsPaused)
            {
                var shot = Instantiate(horizontalBullet, transform.position, new Quaternion());
                shot.GetComponent<Bullet>().source = gameObject;
                shot.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                StartCoroutine("ShotSound");
                shotTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > spawnTime + invulTime)
        {
            if (collision.gameObject.GetComponent<Bullet>() != null)
            {
                var _bullet = collision.gameObject.GetComponent<Bullet>();
                if (_bullet.source != gameObject)
                {
                    Destroy(collision.gameObject);
                    StartCoroutine("DeathSound");
                    Destroy(gameObject);
                }
            }
            else if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                StartCoroutine("DeathSound");
                Destroy(gameObject);
            }
        }
    }

    IEnumerator ShotSound()
    {
        AudioSource.PlayClipAtPoint(shotSound, transform.position);
        yield return new WaitForSeconds(shotSound.length);
    }

    IEnumerator DeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        yield return new WaitForSeconds(deathSound.length);
    }
}
