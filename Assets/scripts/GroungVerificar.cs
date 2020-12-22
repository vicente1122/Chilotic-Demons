using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroungVerificar : MonoBehaviour
{
    private player player1;

    void Start()
    {
        player1 = GetComponentInParent<player>();
    }
    void OnTriggerEnter2D()
    {
        player1.ground = true;
    }
    void OnTriggerStay2D()
    {
        player1.ground = true;
    }
    void OnTriggerExit2D()
    {
        player1.ground = false;
    }
}