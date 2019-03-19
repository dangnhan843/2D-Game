using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Submarine hit = collision.gameObject.GetComponent<Submarine>();
        hit.TakeDamage(5.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroyable bullet = collision.gameObject.GetComponent<Destroyable>();
        Destroy(bullet.gameObject);
    }

}
