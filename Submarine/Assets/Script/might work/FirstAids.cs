using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAids : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1.0f, 0.0f);
    public Vector2 speed = new Vector2(2.0f, 2.0f);
    private Vector2 movement;
    public float lifeTime = 5.0f;

    public float healPoint = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        if (transform.position.x < Camera.main.transform.position.x - 20)
        {
            Destroy(gameObject);
        }
 

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Submarine hit = collision.gameObject.GetComponent<Submarine>();
        hit.HealDamage(10.0f);
        Destroy(this.gameObject);
    }



}
