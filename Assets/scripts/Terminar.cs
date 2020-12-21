using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminar : MonoBehaviour
{
    public string Nivel_Objetivo;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        SceneManager.LoadScene(Nivel_Objetivo);
    }

}
