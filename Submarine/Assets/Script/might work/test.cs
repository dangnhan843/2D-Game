using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < Camera.main.transform.position.x - 15)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            Destroy(hit.gameObject);
            Destroy(this.gameObject);
        }

    }
}
