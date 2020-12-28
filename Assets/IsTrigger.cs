using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    public skelFollow skeleton;
    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log(col.tag);
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.tiempo=0.5f;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {

        Debug.Log(col.tag);
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.tiempo-=Time.deltaTime;
        }
        
    }
    /*void OnTriggerstay2D(Collider2D col)
    {
        col1=col;
        Debug.Log(col.tag);
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.trigger=false;
        }
        else
        {
            skeleton.trigger=false;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        skeleton.trigger=false;/*
        if(col.CompareTag("Player")||col.CompareTag("ground_ver"))
        {
            skeleton.ataque=false;
        }
        
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
