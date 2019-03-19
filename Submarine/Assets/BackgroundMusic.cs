using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    float timer;
    float bossTime = 100.0f;
    public AudioSource audioData;
    bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bossTime)
        {
            audioData.UnPause();
        }
       
    }
}
