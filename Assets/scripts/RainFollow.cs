using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{
    private Vector2 Velocity;
    public float SmoothY;
    public float SmoothX;
    public GameObject Player1;
   


    // Start is called before the first frame update
    void Start()
    {
        Player1=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float posX=Mathf.SmoothDamp(transform.position.x,Player1.transform.position.x,ref Velocity.x,SmoothX);
        float posY=Mathf.SmoothDamp(transform.position.y,Player1.transform.position.y,ref Velocity.y,SmoothY);

        transform.position=new Vector3(posX,transform.position.y,transform.position.z);   
        
    }
    
    
}
