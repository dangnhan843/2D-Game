using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);
    public Rigidbody2D body;
    private Vector2 movement;
    public Vector2 direction;
    public float move = 0.0f;
    public bool rockDestroy = true;
    //public Vector2 direction2 = new Vector2(-1, 0);
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(-1, move);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        if (transform.position.x < Camera.main.transform.position.x - 15)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Submarine hit = collision.gameObject.GetComponent<Submarine>();
        hit.TakeDamage(5.0f);
        Destroy(this.gameObject);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (null != collision.gameObject.GetComponent<Submarine>())
        {
            Submarine hit = collision.gameObject.GetComponent<Submarine>();
            hit.TakeDamage(5.0f);
            Destroy(this.gameObject);
        }
        if (null != collision.gameObject.GetComponent<bullet>())
        {
            bullet hit = collision.gameObject.GetComponent<bullet>();
            if (rockDestroy)
            {
                Score.score += 50;
                rockDestroy = false;
            }
            Destroy(hit.gameObject);
            Destroy(this.gameObject);
        }

    }
}
