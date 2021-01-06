using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int canjump;
    public KeyCode jumpW;
    public KeyCode dash;
    public KeyCode Ataque1;
    public KeyCode Ataque2;
    private int salud_inicial;

    public KeyCode Shake;
    private Rigidbody2D rb2d;   
    public bool ground;
    private Animator anim;
    public ParticleSystem polvo;

    public CameraFollow camFollow;
    private bool ax1Fire;
    private bool ax2Fire;
    public Text textoSalud;
    public float tiempo;
    public float tiempoDash;
    public Collider2D Ataque;
    public bool had2jump;
    public inventario inventario;
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
        if ((Input.GetKey(jump)&&ground)||(Input.GetKeyDown(jump)&&canjump>0)||(Input.GetKey(jumpW))){
            CrearPolvo();
            rb2d.velocity=new Vector2(rb2d.velocity.x,jump_power);
            canjump--;
        }
        if (Input.GetKeyDown(dash))
        {
            tiempoDash=0.1f;
        }
        
    }
    
    void FixedUpdate()
    {
        
        anim.SetBool("ground",ground);
        anim.SetFloat("speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("axFire1",ax1Fire);
        anim.SetBool("axFire2",ax2Fire);
        anim.SetFloat("tiempo",tiempo);
        anim.SetInteger("jumps",canjump);
        //Debug.Log(had2jump);
        /*Debug.Log(inventario.isFull[inventario.selectedSlotInt]);
        if(inventario.isFull[inventario.selectedSlotInt]){
            Debug.Log(inventario.slots[inventario.selectedSlotInt].transform.GetChild(1).gameObject.tag);
        }*/
        

        
        if (had2jump)
        {
            rb2d.velocity=new Vector2(Random.Range(-100,100),jump_power/2);
        }
        
        if (ground)
        {
            canjump=1;
        }
        if(tiempoDash>0)
        {
            tiempoDash-=Time.deltaTime;
        }
        else
        {
            tiempoDash=0;
            rb2d.velocity=new Vector2(rb2d.velocity.x,rb2d.velocity.y);
        }
        
        if (Input.GetKey(dash)&&rb2d.velocity.x<0&&tiempoDash>0)
        {
            rb2d.velocity=new Vector2(-speed*10,rb2d.velocity.y);
            CrearPolvo();
        }
        else if(Input.GetKey(dash)&&rb2d.velocity.x>0&&tiempoDash>0)
        {
            rb2d.velocity=new Vector2(speed*10,rb2d.velocity.y);
            CrearPolvo();
        }

        else if (Input.GetKey(left)&&ax1Fire==false&&ax2Fire==false){
            if(ground) CrearPolvo();
            rb2d.velocity=new Vector2(-speed,rb2d.velocity.y);
            transform.localScale= new Vector3(-1,1,1);

        }
        else if (Input.GetKey(right)&&ax1Fire==false&&ax2Fire==false){
            if (ground) CrearPolvo();
            rb2d.velocity=new Vector2(speed,rb2d.velocity.y);
            transform.localScale= new Vector3(1,1,1);
        }
        else{
            rb2d.velocity=new Vector2((rb2d.velocity.x)*0.8f,rb2d.velocity.y);
        }
        
        /*if ((Input.GetKey(jump)&&ground)||(Input.GetKeyDown(jump)&&canjump>0)||(Input.GetKey(jumpW))){
            CrearPolvo();
            rb2d.velocity=new Vector2(rb2d.velocity.x,jump_power);
            canjump--;
        }*/
        
        if (Input.GetKey(Ataque1)&&ground&&inventario.isFull[inventario.selectedSlotInt]&&inventario.slots[inventario.selectedSlotInt].transform.GetChild(1).gameObject.CompareTag("Hacha"))
        {
            //camFollow.ShakeCamera(1f,0.1f);
            timer(0.45f);
            if(tiempo>=0)
            {
                ax1Fire=true;
                rb2d.velocity= new Vector2(0,0);
                tiempo-=Time.deltaTime;
            }
            
        }
        if (tiempo>=0)
        {
            Ataque.gameObject.SetActive(true);
        }
        else if(Input.GetKey(Ataque2)&&ground&&inventario.isFull[inventario.selectedSlotInt]&&inventario.slots[inventario.selectedSlotInt].transform.GetChild(1).gameObject.CompareTag("Hacha"))
        {
            
            timer(0.85f);
            if(tiempo>=0)
            {
                ax2Fire=true;
                rb2d.velocity= new Vector2(0,0);
                tiempo-=Time.deltaTime;
                
            }
            
        }
        if (tiempo>=0)
        {
            rb2d.velocity= new Vector2(0,0);
            tiempo-=Time.deltaTime;
        }
        if (ax1Fire&&tiempo<=0.1f && tiempo>0)
        {
            camFollow.ShakeCamera(0.5f,0.05f);
        }
        else if (ax2Fire&&tiempo<=0.3f && tiempo>0)
        {
            camFollow.ShakeCamera(2f,0.05f);
        }
        if (tiempo<=0)
        {
            ax1Fire=false;
            ax2Fire=false;
            Ataque.gameObject.SetActive(false);
        }
/*=======/*
        if (Input.GetKey(Shake)){
            camFollow.ShakeCamera(1.5f,0.1f);
>>>>>>> 09737284ff1e12eb93eff95972da9adc3e7e63d5
        }*/
        if (Input.GetKey(Shake))
        {
            camFollow.ShakeCamera(0.15f,115f);
        }
    
    }
    public void timer(float duracion)
    {
        tiempo=duracion;
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
        else {
            salud -= d;
            Debug.Log("daño recibido");
            if (salud <= 0)                      //si pierde toda su vida
            {
                Debug.Log("moriste");
                salud = 0;
                Destroy(this.gameObject);            //muere *agregen animaciones porfa*
            }
            textoSalud.text = salud.ToString();
            float proporcion = (float)salud / (float)salud_inicial; //animacion de salud
            vida.fillAmount = proporcion;
        }
    }
    public void Guardar()                //guarda juego
    {
        SaveSystem.guardarJugador(this);
    }
    public void Cargar()                 //carga juego
    {
        playerData data = SaveSystem.CargarJugador();
        SceneManager.LoadScene(data.nivel);
        salud = data.vida;

        Vector3 position;
        position.x = data.ubicacion[0];
        position.y = data.ubicacion[1];
        position.z = data.ubicacion[2];
        transform.position = position;
    }
}

