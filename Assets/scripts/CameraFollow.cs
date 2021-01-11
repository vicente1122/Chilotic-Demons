using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //kjlkj
    private Vector2 Velocity;
    public float SmoothY;
    public float SmoothX;
    public GameObject Player1;
    public float shakeTimer;
    public float shakeAmount;


    // Start is called before the first frame update
    void Start()
    {
        Player1=GameObject.FindGameObjectWithTag("Player");
    }
    public void ShakeCamera(float shakePwr,float shakeDur)
    {
        shakeAmount=shakePwr;
        shakeTimer=shakeDur;

    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer>=0)
        {
            Vector2 shakePos= Random.insideUnitCircle*shakeAmount;
            transform.position = new Vector3(transform.position.x+shakePos.x,transform.position.y+shakePos.y,transform.position.z);
            shakeTimer -=Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if(Player1!=null)
        {
            float posX=Mathf.SmoothDamp(transform.position.x,Player1.transform.position.x,ref Velocity.x,SmoothX);
            float posY=Mathf.SmoothDamp(transform.position.y,Player1.transform.position.y,ref Velocity.y,SmoothY);
            transform.position=new Vector3(posX,posY,transform.position.z);
        }
           
        
        
    }
    
    
}
