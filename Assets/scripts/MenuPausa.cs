using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public KeyCode Pausar;
    public static bool PausedGame = false;
    public GameObject PausedMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(Pausar))
        {
            if (PausedGame)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PausedMenuUI.SetActive(false);
        Time.timeScale=1;
        PausedGame=false;
    }
    void Pause()
    {
        PausedMenuUI.SetActive(true);
        Time.timeScale=0;
        PausedGame=true;
    }
    public void LoadMenu()
    {
        Time.timeScale=1;
        Debug.Log("loAdiNG MeNu.u");
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("chaolin");
        Application.Quit();
    }
}
