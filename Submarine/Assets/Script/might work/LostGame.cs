using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LostGame : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
      }

    public void Resume()
    {
        SceneManager.LoadScene("Game");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        //SceneManager.LoadScene("Game");
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
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