using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    public List<Ink> projectiles = new List<Ink>();
    public Ink projectilePrefab;
    public float timer;
    public Transform projectileSpawnLocation;
    public int maxProjectiles = 3;
    public Vector2 movement;
    public Vector2 speed = new Vector2(2.0f, 2.0f);
    public Vector2 direction = new Vector2(-1.0f, 0.0f);
    public float hitpoint = 30.0f;
    public bool squidDie = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.0f)
        {
 
            if (projectiles.Count < maxProjectiles)
            {

                Ink newProjectile = Instantiate<Ink>(projectilePrefab);
                newProjectile.transform.position = projectileSpawnLocation.position;
                newProjectile.playerOwner = this;
                projectiles.Add(newProjectile);
            }
            timer = 0.0f;

            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

            if (transform.position.x < Camera.main.transform.position.x - 20)
            {
                Destroy(gameObject);
            }
        }
    }
        private void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().velocity = movement;
        }

        public void ProjectileDestroyed(Ink projectileThatWasDestroyed)
    {
        projectiles.Remove(projectileThatWasDestroyed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
        if (null != otherCollider.gameObject.GetComponent<bullet>())
        {
            
            bullet hit = otherCollider.gameObject.GetComponent<bullet>();
            Destroy(hit.gameObject);
            hitpoint -= 11.0f;
            if (hitpoint <= 0.0f)
            {
                if (squidDie)
                {
                    Score.score += 200;
                    squidDie = false;
                }
                Destroy(gameObject);
            }
        }

    }
}

