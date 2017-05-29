using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed = 4;
    private float _trueSpeed;
    public int health = 1;
    public float shotCooldown = 1;
    public float moveCooldown = 0.12f;
    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();
    public GameObject horizontalBullet;
    public GameObject verticalBullet;
    private float shotTime;
    private float moveTime;
    public AudioClip shotSound;
    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
        _trueSpeed = speed * 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= moveTime + moveCooldown)
        {
            var randDirection = Random.Range(0, 4);
            switch (randDirection)
            {
                case 0:
                    if (transform.position.x <= bottomBounds.x)
                    {
                        transform.position += new Vector3(_trueSpeed, 0, 0);
                        if (transform.position.x >= bottomBounds.x)
                        {
                            transform.position = new Vector3(bottomBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 1:
                    if (transform.position.x >= topBounds.x)
                    {
                        transform.position += new Vector3(-_trueSpeed, 0, 0);
                        if (transform.position.x <= topBounds.x)
                        {
                            transform.position = new Vector3(topBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 2:
                    if (transform.position.y <= topBounds.y)
                    {
                        transform.position += new Vector3(0, _trueSpeed, 0);
                        if (transform.position.y >= topBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, topBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 3:
                    if (transform.position.y >= bottomBounds.y)
                    {
                        transform.position += new Vector3(0, -_trueSpeed, 0);
                        if (transform.position.y <= bottomBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, bottomBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
            }

            if (Time.time >= shotTime + shotCooldown)
            {
                var randShot = Random.Range(0, 2);
                if (randShot == 0)
                {
                    GameObject shot;
                    switch (randDirection)
                    {
                        case 0:
                            shot = Instantiate(horizontalBullet, transform.position, new Quaternion());
                            shot.GetComponent<Bullet>().source = gameObject;
                            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                            StartCoroutine("ShotSound");
                            shotTime = Time.time;
                            break;
                        case 1:
                            shot = Instantiate(horizontalBullet, transform.position, new Quaternion());
                            shot.GetComponent<Bullet>().source = gameObject;
                            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                            StartCoroutine("ShotSound");
                            shotTime = Time.time;
                            break;
                        case 2:
                            shot = Instantiate(verticalBullet, transform.position, new Quaternion());
                            shot.GetComponent<Bullet>().source = gameObject;
                            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                            StartCoroutine("ShotSound");
                            shotTime = Time.time;
                            break;
                        case 3:
                            shot = Instantiate(verticalBullet, transform.position, new Quaternion());
                            shot.GetComponent<Bullet>().source = gameObject;
                            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                            StartCoroutine("ShotSound");
                            shotTime = Time.time;
                            break;
                    }
                }

            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            var _bullet = collision.gameObject.GetComponent<Bullet>();
            if (_bullet.source == player)
            {
                Destroy(collision.gameObject);
                Player.score += 50;
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
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 10);
        yield return new WaitForSeconds(deathSound.length);
    }
}
