using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Submarine : MonoBehaviour
{
    public Animator anim;
    
    private bool checkAnimation = false;

    //public float health = 100.0f;
    public Rigidbody2D body;
    public GameObject submarine;
    public Vector2 speed = new Vector2(5.0f,5.0f);
    private Vector2 movement;
    public float numberOfBullet = 99999.0f;
    private float inputX;
    private float inputY;

    // shoot Bullet
    public int maxProjectiles = 3;
    public Transform projectileSpawnLocation;
    public bullet projectilePrefab;
    public List<bullet> projectiles = new List<bullet>();

    // add delay between rocket
    public float delayTimeEnd = 0.0f;
    public float delayTime = 10.0f;
    public float currentTime = 0.0f;


    // User Interface
    public Image currentHealthbar;
    public Text ratioText;
    public float startHealth;
    float timer;
    public float hitpoint = 100.0f;
    public float maxHitpoint = 100.0f;
    public float timeEndScene;
    public float waitTime = 2.0f;
    public bool subDie = true;
    // Sound effect
    public GameObject canvas;
    public AudioSource bulletSound;
    public AudioSource audioData;



    // Start is called before the first frame update
    void Start()
    {
        startHealth = maxHitpoint;
        anim = GetComponent<Animator>();
        UpdateHealthbar();
        audioData.Play(0);
        audioData.Pause();
    }

    // Update is called once per frame
    void Update()
    {

        if(hitpoint < 0.0f)
        {
            //SceneManager.LoadScene("Menu");
            anim.ResetTrigger("Active");
            anim.ResetTrigger("Active");
            anim.SetTrigger("Explode");
            timeEndScene += Time.deltaTime;
            if (subDie)
            {
                numberOfBullet = 0.0f;
                subDie = false;

            }
            audioData.UnPause();
            if (timeEndScene > waitTime)
            {
                canvas.SetActive(true);
                Destroy(this.gameObject);
            }
            

        }

        // no rotate
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        // input controller
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.0f,0.0f,dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, dist)).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
            );

        currentTime = Time.time;
        
        if (Input.GetButtonDown("Fire1"))
        {
            //shoot.Play("shoot");
            if (numberOfBullet > 1.0f)
            {
                if (currentTime > delayTimeEnd)
                {

                    //anim.SetTrigger("Active");
                    if (projectiles.Count < maxProjectiles)
                    {
                        bullet newProjectile = Instantiate<bullet>(projectilePrefab);
                        newProjectile.transform.position = projectileSpawnLocation.position;
                        newProjectile.playerOwner = this;
                        bulletSound.Play();
                        anim.SetTrigger("Active");

                        projectiles.Add(newProjectile);
                    }
                    numberOfBullet--;
                    //if (checkAnimation = true)
                    //{
                    //    StartCoroutine(CheckAnim());
                    //}
                    delayTimeEnd = currentTime + delayTime;
                }
            }
            
        }
        
    }
        
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //transform.rotation = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //SharkScript hit = otherCollider.gameObject.GetComponent<SharkScript>();
        //GroundTile hit2 = otherCollider.gameObject.GetComponent<GroundTile>();
        //collision.gameObject.name == "MyGameObjectName"
        if (null != otherCollider.gameObject.GetComponent<Destroyable>())
        {
            Destroyable hit = otherCollider.gameObject.GetComponent<Destroyable>();
            Destroy(hit.gameObject);

            //hitpoint = hitpoint - 10.0f;
            TakeDamage(10.0f);
            
        }
        
    }

    public void ProjectileDestroyed(bullet projectileThatWasDestroyed)
    {
        projectiles.Remove(projectileThatWasDestroyed);
    }


    void UpdateHealthbar()
    {
        currentHealthbar.fillAmount = hitpoint / startHealth;
        //float ratio = hitpoint / maxHitpoint;
        //currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //ratioText.text = (ratio * 100).ToString('0') + '%';
    }

    public void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            
            Debug.Log("Dead!");
            //FindObjectOfType<GameManager>().EndGame();
            //Destroy(this.gameObject);
        }
        UpdateHealthbar();
    }

    public void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }
        UpdateHealthbar();
    }



}
