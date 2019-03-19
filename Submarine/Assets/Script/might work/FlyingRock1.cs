using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock1 : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(rock, 5.0f);
    }
}
