using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float hitpoint = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (null != otherCollider.gameObject.GetComponent<bullet>())
        {
            bullet hit = otherCollider.gameObject.GetComponent<bullet>();
            Destroy(hit.gameObject);

            hitpoint -= 2.0f;
            if (hitpoint <= 0.0f)
            {
                Destroy(gameObject);
            }
        }

    }
}
