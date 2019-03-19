using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss playerOwner;
    public Vector2 pos;
    public float speeed = 5.0f;
    private Vector2 movement;
    public AudioSource lazer;
    void Start()
    {
        pos = new Vector2(Random.Range(-15.0f, 0.0f), Random.Range(-4.5f, 4.5f));
        lazer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, pos, Time.deltaTime * speeed);
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
