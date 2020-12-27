using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D col=null;
    public float speed;
    public bool ground=false;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D col0)
    {
        col=col0;
        ground=true;
    }
    void OnTriggerExit2D()
    {
        ground=false;
    }
    // Update is called once per frame
    void Update()
    {
        if (col!=null&&col.CompareTag("Water")&&ground)
        {
            rb.velocity=new Vector2(rb.velocity.x,speed);
        }
        else if(col!=null)
        {
            rb.velocity=rb.velocity;
        }
    }
}
