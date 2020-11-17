using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;
    public float speed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(right))
        {
            rb2d.velocity=new Vector2(speed,rb2d.velocity.y);
            transform.localScale=new Vector3(1,1,1);
        }  
        else if(Input.GetKey(left))
        {
            rb2d.velocity=new Vector2(-speed,rb2d.velocity.y);
            transform.localScale=new Vector3(-1,1,1);
        }
        else{
            rb2d.velocity=new Vector2((rb2d.velocity.x)*0.8f,rb2d.velocity.y);
        }
        if(Input.GetKey(up))
        {
            rb2d.velocity=new Vector2(rb2d.velocity.x,speed);
        }
        else if(Input.GetKey(down))
        {
            rb2d.velocity=new Vector2(rb2d.velocity.x,-speed);
        }
        else{
            rb2d.velocity=new Vector2(rb2d.velocity.x,(rb2d.velocity.y)*0.8f);
        }
           
    }
}
