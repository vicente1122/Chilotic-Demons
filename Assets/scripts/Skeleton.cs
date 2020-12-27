using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public KeyCode jump;
    public KeyCode right;
    public KeyCode left;
    private Rigidbody2D skel;
    private Animator anim;
    public float speed;
    public bool run=false;

    public Collider2D col=null;
    // Start is called before the first frame update
    void Start()
    {
        skel=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (skel.velocity.x<0)
        {
            transform.localScale= new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale= new Vector3(1,1,1);
        }*/
        //anim.SetFloat("speed",Mathf.Abs(skel.velocity.x));
        anim.SetBool("run",run);
        if(Input.GetKey(right))
        {
            
            skel.velocity=new Vector2(speed,skel.velocity.y);
        }
        else if(Input.GetKey(left))
        {
            
            skel.velocity=new Vector2(-speed,skel.velocity.y);
        }
        if(Input.GetKey(jump))
        {
            skel.velocity=new Vector2(skel.velocity.x,speed);
        }
        else
        {
            skel.velocity=new Vector2(skel.velocity.x*0.85f,skel.velocity.y);
        }
        if (col!=null&&col.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(skel.GetComponent<Collider2D>(),col);
        }
    }
}
