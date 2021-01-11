using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofre : MonoBehaviour
{
    public GameObject mensaje;
    public bool puedeabrir;
    public KeyCode AbrirCofre;
    public GameObject items;
    public player p1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(AbrirCofre)&&puedeabrir)
     {
        items.gameObject.SetActive(true);
        puedeabrir=false;
        mensaje.gameObject.SetActive(false);
     }   
    }
    void OnTriggerEnter2D()
    {
        mensaje.gameObject.SetActive(true);
        puedeabrir=true;
    }
    void OnTriggerExit2D()
    {
        mensaje.gameObject.SetActive(false);
        puedeabrir=false;
    }
}
