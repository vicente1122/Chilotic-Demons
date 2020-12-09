using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void RecibeDaño(int daño)
    {
        vida -= daño;
        Debug.Log("daño recibido");
    }

}
