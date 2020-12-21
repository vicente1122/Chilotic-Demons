using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Image vida;
    public int evasion; //posibilidad de esquivar ataques en %
    public int salud;  //total de vida
    public float speed;
    public float jump_power;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode jumpW;
    public Text textoSalud;
    public bool ground;
    public ParticleSystem polvo;
    private int salud_inicial;
    private Animator anim;
    private Rigidbody2D rb2d;   
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        textoSalud.text = salud.ToString();
        salud_inicial = salud;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        
        anim.SetBool("ground",ground);
        anim.SetFloat("speed",Mathf.Abs(rb2d.velocity.x));
        
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
    }
    void CrearPolvo()
    {
        polvo.Play();
    }
    public void RecibeDaño(int d)         //cuando recibe daño
    {
        int num = Random.Range(1, 101); //probablidades
        if (num < evasion) //logra evadir
        {
            d = d * 0;    //esquiva ataque
            Debug.Log("esquivaste un ataque");
        }
        else
        {
            salud -= d;
            float proporcion = (float)salud / (float)salud_inicial; //animacion de salud
            vida.fillAmount = proporcion;
            Debug.Log("daño recibido");
            if (salud <= 0)                      //si pierde toda su vida
            {
                Debug.Log("moriste");
                salud = 0;
                Destroy(this.gameObject);            //muere *agregen animaciones porfa*
            }
        }
        textoSalud.text = salud.ToString();
    }
}
