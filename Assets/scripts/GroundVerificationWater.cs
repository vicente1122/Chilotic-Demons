using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroungVerificarAgua : MonoBehaviour
{
    private player player1;

    public GameObject water;

    void Start()
    {
        //water=GetComponent<GameObject>();
        player1 = GetComponentInParent<player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == water.gameObject.tag)
        {
            player1.ground = false;
        }
        else
        {
            player1.ground = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == water.gameObject.tag)
        {
            player1.ground = false;
        }
        else
        {
            player1.ground = true;
        }
    }
    void OnTriggerExit2D()
    {
        player1.ground = false;
    }
}
