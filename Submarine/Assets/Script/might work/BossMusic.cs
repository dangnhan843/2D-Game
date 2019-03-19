using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    public AudioClip impact;

    AudioSource audioSource;
    float timer;
    float bossTime = 98.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > bossTime)
        {
            audioSource.PlayOneShot(impact, 0.7F);
        }


    }
}
