using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    public skelFollow skeleton;
    public Collider2D col1=null;
    void OnTriggerEnter2D(Collider2D col)
    {
        col1=col;
        Debug.Log(col.tag);
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.ataque=true;
        }
        else
        {
            skeleton.ataque=false;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        col1=col;
        Debug.Log(col.tag);
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.ataque=true;
        }
        else
        {
            skeleton.ataque=false;
        }
    }
    /*void OnTriggerStay(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            skeleton.ataqueModo=true;
        }
    }*/
    void OnTriggerExit2D(Collider2D col)
    {
        skeleton.ataque=false;/*
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.ataque=false;
        }*/
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
