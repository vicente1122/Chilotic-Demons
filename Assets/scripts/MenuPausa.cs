using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public KeyCode Pausar;
    public KeyCode LeerNota;
    public static bool PausedGame = false;
    public GameObject PausedMenuUI;
    public GameObject Nota;
    public GameObject mensaje;
    public static bool leyendoNota=false;
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
                mensaje.SetActive(false);
            }
        }
        if (Input.GetKeyDown(LeerNota)&&!PausedGame)
        {
            if(leyendoNota)
            {
                salirNota();
            }
            else
            {
                leerNota();
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
    public void leerNota()
    {
        leyendoNota=true;
        Nota.SetActive(true);
        Time.timeScale=0;
        
    }
    public void salirNota()
    {
        leyendoNota=false;
        Nota.SetActive(false);
        Time.timeScale=1;
        mensaje.SetActive(false);
    }
}
