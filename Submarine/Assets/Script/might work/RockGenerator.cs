using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{

    public Transform enemyPrefab;
    public GameObject thisObject;
    private double i = 0;
    private double j = 0;
    float time = 30.0f;
    float timer;
    float destroyTime = 50.0f;
    float timeCount;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            thisObject.SetActive(false);
        }

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
                enemyTransform.position = new Vector3(Random.Range(-10.0f, 14.0f), 3.0f, -2.0f);
                j = i;
            }
        }



    }

}
