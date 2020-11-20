using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTD : MonoBehaviour
{
    public float speed;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    private Rigidbody2D rb2d;   

    public Transform ground_ver;
    public float ground_radius;
    public bool ground;
    public LayerMask what_is_ground;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        ground=Physics2D.OverlapCircle(ground_ver.position,ground_radius,what_is_ground);
        if (Input.GetKey(left)){
            rb2d.velocity=new Vector2(-speed, rb2d.velocity.y);
            transform.localScale=new Vector3(-1,1,1);

        }
        else if (Input.GetKey(right)){
            rb2d.velocity=new Vector2(speed, rb2d.velocity.y);
            transform.localScale=new Vector3(1,1,1);
        }

        else if (Input.GetKey(up)){
            rb2d.velocity=new Vector2(rb2d.velocity.x, speed);
        }
        else if (Input.GetKey(down)){
            rb2d.velocity=new Vector2(rb2d.velocity.x, -speed);
        }
        else{
            rb2d.velocity = new Vector2((rb2d.velocity.x) * 0, (rb2d.velocity.y) * 0);
        }
    }
}
