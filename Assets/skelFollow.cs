using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelFollow : MonoBehaviour
{
    private Vector2 Velocity;
    public float SmoothY;
    public float SmoothX;
    public float distancia;
    public GameObject Player1;
    private Rigidbody2D skel;
    public bool running;
    public bool ataque;
    private Animator anim;
    public Material MatBlanco;
    private Material MatDefault;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        skel=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        Player1=GameObject.FindGameObjectWithTag("Player");
        spriteRenderer=GetComponent<SpriteRenderer>();
        //MatBlanco=Resources.Load("WhiteFlash",typeof(Material)) as Material;
        MatDefault=spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        anim.SetBool("run",running);
        anim.SetFloat("speed",Mathf.Abs(skel.velocity.x));
        anim.SetBool("ataque",ataque);
        float posX=Mathf.SmoothDamp(transform.position.x,Player1.transform.position.x,ref Velocity.x,SmoothX);
        float posY=Mathf.SmoothDamp(transform.position.y,Player1.transform.position.y,ref Velocity.y,SmoothY);

        
        Debug.Log(Mathf.Abs(transform.position.x-Player1.transform.position.x));
        if (Mathf.Abs(transform.position.x-Player1.transform.position.x)<30f)
        {
            transform.position=transform.position;
            running=false;
            ataque=true;
        }
        else if (Mathf.Abs(transform.position.x-Player1.transform.position.x)>100f)
        {
            transform.position=transform.position;
            running=false;
            ataque=false;
        }
        else
        {
            transform.position=new Vector3(posX*distancia,transform.position.y,transform.position.z);
            running=true;
            ataque=false;
        }
        if (transform.position.x-Player1.transform.position.x>0)
        {
            transform.localScale= new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale= new Vector3(1,1,1);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("AttackArea"))
        {

            Debug.Log("ataque");
            spriteRenderer.material=MatBlanco;
            Invoke("resetMat",0.2f);
        }
    }
    void resetMat()
    {
        spriteRenderer.material=MatDefault;
    }
    
    
}
