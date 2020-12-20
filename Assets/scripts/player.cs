using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public int evasion; //posibilidad de esquivar ataques en %
    public int salud;  //total de vida
    public float speed;
    public float jump_power;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode jumpW;

    public KeyCode Ataque1;
    public KeyCode Ataque2;
    private Rigidbody2D rb2d;   
    public bool ground;
    private Animator anim;
    public ParticleSystem polvo;

    public CameraFollow camFollow;
    private bool ax1Fire;
    private bool ax2Fire;
    public float tiempo;

    public Text textoSalud;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        textoSalud.text = "Salud:" + salud.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        
        anim.SetBool("ground",ground);
        anim.SetFloat("speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("ax1Fire",ax1Fire);
        anim.SetBool("ax2Fire",ax2Fire);
        
        if (Input.GetKey(left)){
            if(ground) CrearPolvo();
            rb2d.velocity=new Vector2(-speed,rb2d.velocity.y);
            transform.localScale= new Vector3(-1,1,1);

        }
        else if (Input.GetKey(right)){
            if (ground) CrearPolvo();
            rb2d.velocity=new Vector2(speed,rb2d.velocity.y);
            transform.localScale= new Vector3(1,1,1);
        }
        else{
            rb2d.velocity=new Vector2((rb2d.velocity.x)*0.8f,rb2d.velocity.y);
        }
        if (Input.GetKey(jump) && ground || Input.GetKey(jumpW)){
            CrearPolvo();
            rb2d.velocity=new Vector2(rb2d.velocity.x,jump_power);
        }
        if (Input.GetKey(Ataque1)&&ground)
        {
            //camFollow.ShakeCamera(1f,0.1f);
            timer(0.5f);
            if(tiempo>=0)
            {
                ax1Fire=true;
                rb2d.velocity= new Vector2(0,0);
                tiempo-=Time.deltaTime;
            }
            
        }
        else if(Input.GetKey(Ataque2)&&ground)
        {
            
            timer(0.8f);
            if(tiempo>=0)
            {
                ax2Fire=true;
                rb2d.velocity= new Vector2(0,0);
                tiempo-=Time.deltaTime;
                
            }
            
        }
        if (ax1Fire&&tiempo<=0.5f && tiempo>0)
        {
            camFollow.ShakeCamera(0.5f,0.01f);
        }
        else if (ax2Fire&&tiempo<=0.3f && tiempo>0)
        {
            camFollow.ShakeCamera(1f,0.1f);
        }
        if (tiempo<=0)
        {
            ax1Fire=false;
            ax2Fire=false;
        }

        if (tiempo>=0)
        {
            //ax1Fire=true;
            rb2d.velocity=new Vector2(0,0);
            tiempo-=Time.deltaTime;
        }
        /*else{
            ax1Fire=false;
        }*/
    }
    void CrearPolvo()
    {
        polvo.Play();
    }
    /*void ataque1(float duracion)
    {
        timer(duracion);
        if (tiempo>=0)
            {
                ax1Fire=true;
                rb2d.velocity=new Vector2(0,0);
                tiempo-=Time.deltaTime;
            }
        else{
            ax1Fire=false;
            }
    }*/
    public void timer(float duracion)
    {
        tiempo=duracion;
    }
    public void RecibeDaño(int d)         //cuando recibe daño
    {
        int num = Random.Range(1, 101); //probablidades
        if (num < evasion) //logra evadir
        {
            d = d * 0;    //esquiva ataque
            Debug.Log("esquivaste un ataque");
        }
        else {
            salud -= d;
            Debug.Log("daño recibido");
            if (salud <= 0)                      //si pierde toda su vida
            {
                Debug.Log("moriste");
                salud = 0;
                Destroy(this.gameObject);            //muere *agregen animaciones porfa*
            }
            textoSalud.text = "Salud:" + salud.ToString();
        }
    }
}
