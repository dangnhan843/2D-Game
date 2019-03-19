using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    private Vector2 movement;
    float timer;
    public float speeed = 5.0f;
    public Vector2 speed = new Vector2(20.0f, 20.0f);
    public Vector2 direction;
    float xx, yy;
    public Vector2 pos;
    public Squid playerOwner;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(-4.5f, 4.5f));
    }

    // Update is called once per frame
    void Update()
    {
       
        xx = speed.x * direction.x;
        yy = speed.y * direction.y;
        //movement = new Vector2(xx, yy);
        //transform.position = direction;
        transform.position = Vector2.Lerp(transform.position, pos, Time.deltaTime * speeed);
        //transform.position = Vector2.MoveTowards(transform.position, submarine.transform.position, speeed);
        timer += Time.deltaTime;
        if (timer > 4.0f)
        {
            playerOwner.ProjectileDestroyed(this);
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
