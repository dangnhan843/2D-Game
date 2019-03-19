using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Destroy(gameObject);
        SharkScript hit = otherCollider.gameObject.GetComponent<SharkScript>();
       
        if (hit != null)
        {
            Destroy(hit.gameObject);
            Destroy(gameObject);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + 1);

            
        }


    }

}
