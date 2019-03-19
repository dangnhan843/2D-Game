using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // controll bullet speed
    float currentSpeed = 0.1f;
    float maxSpeed = 200f;
    private float minSpeed;
    private float time;

    // bullet out of camera
    //public Camera mainCamera;
    //public Vector2 widthThresold;
    //public Vector2 heightThresold;


    public int score;
    public float accelerationTime = 2.0f;
    public Vector2 speed = new Vector2(20.0f, 20.0f);
    public Vector2 direction = new Vector2(1.0f, 0.0f);
    public Vector2 checkStop = new Vector2(0.0f, 0.0f);
    public float xx;
    public float yy;
    private Vector2 movement;
    public Submarine playerOwner;
    public float lifetime = 0.5f;
    float timer;
    public GameObject submarine;
    public GameObject smoke;

    public float fireDelay = 0.1f;
    private float fireTimestamp = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        fireTimestamp = Time.realtimeSinceStartup + fireDelay;
        //Instantiate(smoke, transform.position, Quaternion.identity);
        minSpeed = currentSpeed;
        time = 0;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            Debug.Log("moving");
        }
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //transform.position = submarine.transform.position;
        //Instantiate(smoke, transform.position, Quaternion.identity);
        if (Time.realtimeSinceStartup > fireTimestamp)
        {
            
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            speed = new Vector2(currentSpeed, currentSpeed);
            xx = speed.x * direction.x;
            yy = speed.y * direction.y;
            movement = new Vector2(xx, yy);

            time += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer > 1.2f)
            {
                playerOwner.ProjectileDestroyed(this);
                Destroy(this.gameObject);
            }
            if(currentSpeed == 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
        

        //Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        //if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
       //     Destroy(gameObject);




    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroyable destroyable = col.GetComponent<Destroyable>();
        
        if (destroyable)
        {
            //Destroy(destroyable.gameObject);
            Score.score += 100;
        }
        Destroy(destroyable.gameObject);
        playerOwner.ProjectileDestroyed(this);
        Destroy(this.gameObject);
    }
}
