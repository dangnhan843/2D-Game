using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidArmy : MonoBehaviour
{
    public GameObject squidArmy;
    public Transform enemyPrefab;
    private double i = 0;
    private double j = 0;
    float time = 65.0f;
    float timer;
    float destroyTime = 75.0f;
 
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            squidArmy.SetActive(false);
        }
        if (destroyTime >= 0.0f)
            if (time >= 0.0f)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {

                i = Time.realtimeSinceStartup;
                if ((i - j) > 1)
                {
                    var enemyTransform = Instantiate(enemyPrefab) as Transform;
                    enemyTransform.position = new Vector3(15.0f, Random.Range(-2.0f, 2.0f), -2.0f);
                    j = i;
                }
            }
    }
}
