using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10.0f, 10.0f);
    public Vector2 direction = new Vector2(-1.0f, 0.0f);
    private Vector2 movement;
    public float healDropRandom;

    public FirstAids healDrop;
    public ParticleSystem deadEffect;

    // Start is called before the first frame update
    void Start()
    {
        healDropRandom = Random.Range(-10.0f, 10.0f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (null != collision.gameObject.GetComponent<bullet>())
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
            if (healDropRandom > 0.0f)
            {
                Instantiate(healDrop, transform.position, transform.rotation);
            }
        }
    }

}

