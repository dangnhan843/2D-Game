using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    public static bool win = false;
    public GameObject WinUI;
    public Boss boss;
    // Update is called once per frame
    void Update()
    {
        if (boss.hitpoint < 0.0f)
        {
            Debug.Log("Win");
            if (win)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        WinUI.SetActive(false);
        Time.timeScale = 1f;
        win = false;
    }
    void Pause()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f;
        win = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
