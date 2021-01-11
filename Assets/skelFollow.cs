using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skelFollow : MonoBehaviour
{
    public LayerMask que_es_objetivo; //se asigna quien califica como enemigo
    public Transform player;
    public float Rango; //rango de ataque
    public Transform PosAtaque; //se donde viene el ataque
    public int daño; //daño MINIMO que puede hacer

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
    public bool reanim=false;
    public float tiempo;
    public bool trigger=false;
    public Collider2D col;


    // Start is called before the first frame update
    void Start()
    {
        skel=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        Player1=GameObject.FindGameObjectWithTag("Player");
        spriteRenderer=GetComponent<SpriteRenderer>();
        //MatBlanco=Resources.Load("WhiteFlash",typeof(Material)) as Material;
        MatDefault=spriteRenderer.material;
        //col.gameObject.SetActive(true);
        //tiempo=-1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        anim.SetBool("run", running);
        anim.SetFloat("speed", tiempo);
        anim.SetBool("ataque", ataque);
        anim.SetBool("reanim", reanim);
        if (Player1!=null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, Player1.transform.position.x, ref Velocity.x, SmoothX);
            float posY = Mathf.SmoothDamp(transform.position.y, Player1.transform.position.y, ref Velocity.y, SmoothY);

            if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 30f)
            {
                transform.position = transform.position;
                running = false;
                ataque = true;
            }
            else if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 100f)
            {
                transform.position = new Vector3(posX * distancia, transform.position.y, transform.position.z);
                running = true;
                ataque = false;
            }
            else if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 150f)
            {
                reanim=true;
            }
            else
            {
                transform.position = transform.position;
                running = false;
                ataque = false;
            }
            if (transform.position.x - Player1.transform.position.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            running=false;
            ataque=false;
        }
        /*float posX = Mathf.SmoothDamp(transform.position.x, Player1.transform.position.x, ref Velocity.x, SmoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player1.transform.position.y, ref Velocity.y, SmoothY);

        if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 30f)
        {
            transform.position = transform.position;
            running = false;
            ataque = true;
        }
        else if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 100f)
        {
            transform.position = new Vector3(posX * distancia, transform.position.y, transform.position.z);
            running = true;
            ataque = false;
        }
        else if (Mathf.Abs(transform.position.x - Player1.transform.position.x) < 150f)
        {
            reanim=true;
        }
        else
        {
            transform.position = transform.position;
            running = false;
            ataque = false;
        }
        if (transform.position.x - Player1.transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
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

    public void InflijeDaño()
    {
            Collider2D[] enemigosDañados = Physics2D.OverlapCircleAll(PosAtaque.position, Rango, que_es_objetivo);
            for (int i = 0; i < enemigosDañados.Length; i++)
            {
                enemigosDañados[i].GetComponent<player>().RecibeDaño(daño);
            }
    }

}
