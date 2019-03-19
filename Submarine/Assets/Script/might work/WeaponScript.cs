using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float numberOfBullet = 5.0f;
    public float nexBulletTime = 0.0f;
    public float rechargeBulletTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nexBulletTime)
        {
            nexBulletTime += rechargeBulletTime;

        }
        //bool shoot = Input.GetButtonDown("Fire1");
        if (numberOfBullet > 0.0f )

        {
            bool shoot = Input.GetButtonDown("Fire1");
            if (shoot)
            {
                var shotTransform = Instantiate(shotPrefab) as Transform;
                shotTransform.position = transform.position + new Vector3(2.0f, 0.0f, 0.0f);
                numberOfBullet--;
            }
            
        }
    }
}
