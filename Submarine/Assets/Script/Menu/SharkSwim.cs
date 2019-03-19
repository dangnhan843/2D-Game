using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkSwim : MonoBehaviour
{
    public float zValue = 0.0f;
    public float yValue = 0.0f;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            count += 1;
            zValue += 90.0f;
            yValue += 180.0f;
        }
        if (count ==1)
        {
            transform.position = new Vector2(1.0f, 45.0f);
        }
    }
}
