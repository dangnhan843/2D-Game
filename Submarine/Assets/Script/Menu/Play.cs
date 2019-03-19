using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void Load(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
