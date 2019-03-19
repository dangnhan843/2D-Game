using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoop : MonoBehaviour
{
    public MovieTexture movTexture;
    void Start()
    {
        movTexture.loop = true;
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
}
