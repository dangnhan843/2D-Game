using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CataBomb : MonoBehaviour
{
    public GameObject Submarine;
    protected bool letShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            letShoot = !letShoot;
            print("space key was pressed");
            transform.position = Submarine.transform.position;
        }
        if(letShoot)
        {
            if (!gameObject.GetComponent<ParticleSystem>().isPlaying) 
            {
                gameObject.GetComponent<ParticleSystem>().Play();
            }
            else if (gameObject.GetComponent<ParticleSystem>().isPlaying)
            {
                gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
    }

}
