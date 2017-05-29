using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();
    public GameObject source;
    private float buffer = .1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > topBounds.y + buffer || transform.position.y < bottomBounds.y - buffer || transform.position.x < topBounds.x - buffer || transform.position.x > bottomBounds.x + buffer)
        {
            Destroy(gameObject);
        }		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            var _bullet = collision.gameObject.GetComponent<Bullet>();
            if (_bullet.source != gameObject && _bullet.source != source)
            {
                try
                {
                    if (_bullet.source.GetComponent<Player>() != null)
                    {
                        Player.score += 10;
                        Destroy(collision.gameObject);
                        Destroy(gameObject);
                    }
                }
                catch { }
            }
        }
    }
}
