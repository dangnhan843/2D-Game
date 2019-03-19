using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 movement;
    public GameObject canvas;
    public Vector2 speed = new Vector2(2.0f, 2.0f);
    public Vector2 direction = new Vector2(-1.0f, 0.0f);
    public float hitpoint = 10.0f;
    public Animator anim;
    // Start is called before the first frame update
   
    float destroyTime = 100.0f;
    public AudioSource audioData;
    public List<Blue> projectiles = new List<Blue>();
    public Blue projectilePrefab;
    public float timer;
    public float timer2;
    public Transform projectileSpawnLocation;
    public int maxProjectiles = 100;
    public bool bossDie = true;
    public float timeEndScene;
    public float waitTime = 5.0f;
    void Start()
    {
        canvas.SetActive(false);
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitpoint < 0.0f)
        {
            //SceneManager.LoadScene("Menu");
            anim.ResetTrigger("Active");
            anim.SetTrigger("Die");
            timeEndScene += Time.deltaTime;
            if (bossDie)
            {
                Score.score += 10000;
                bossDie = false;
            }
            audioData.UnPause();
            if(timeEndScene > waitTime)
            {
                canvas.SetActive(true);
            }
            
        }
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            movement = new Vector2(0.0f,0.0f);
            anim.SetTrigger("Active");
            if (timer2 > 2.0f)
            {

                if (projectiles.Count < maxProjectiles)
                {

                    Blue newProjectile = Instantiate<Blue>(projectilePrefab);
                    newProjectile.transform.position = projectileSpawnLocation.position;
                    newProjectile.playerOwner = this;
                    projectiles.Add(newProjectile);

                    Blue newProjectile2 = Instantiate<Blue>(projectilePrefab);
                    newProjectile2.transform.position = projectileSpawnLocation.position;
                    newProjectile2.playerOwner = this;
                    projectiles.Add(newProjectile2);

                    Blue newProjectile3 = Instantiate<Blue>(projectilePrefab);
                    newProjectile3.transform.position = projectileSpawnLocation.position;
                    newProjectile3.playerOwner = this;
                    projectiles.Add(newProjectile3);
                }
                timer2 = 0.0f;

            }
        }
        else
        {
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        }

        
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (null != otherCollider.gameObject.GetComponent<bullet>())
        {
            bullet hit = otherCollider.gameObject.GetComponent<bullet>();
            Destroy(hit.gameObject);

            hitpoint -= 5.0f;
            
        }

    }
}
