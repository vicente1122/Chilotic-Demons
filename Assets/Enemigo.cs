using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public float dimension_x;    //para evitar problemas de orientacion y asignar las dimensiones
    public float dimension_y;
    public int salud;  //total de vida, este se cambia
    public float velocidad;
    public float distancia;     //a que distancia detecta el suelo
    public Transform deteccionSuelo;
    private float velocidad2;
    private Rigidbody2D rb2d;
    private bool avanzandoIzquierda = true;
    private bool presente = false;
    //variables de combate abajo
    public float Vista; //rango visual
    public float Rango; //rango de ataque
    public int daño; //daño MINIMO que puede hacer
    public LayerMask que_es_objetivo; //se asigna quien califica como enemigo
    public Transform PosAtaque; //se donde viene el ataque
    public float IniciartiempoEntreAtaque; //cuenta el tiempo que pasa entre ataques
    public Transform player;
    private float tiempoEntreAtaque; //cuenta el tiempo que pasa
    private int salud_inicial; //total de vida inicial, no se cambia

    public Image vida;    // Para desplegar la vida de forma visible
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocidad2 = velocidad;
        salud_inicial = salud;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(deteccionSuelo.position, Vector2.down, distancia);   //sensor de si se le acaba el suelo
        if ((((player.transform.position.x - transform.position.x) * (player.transform.position.x - transform.position.x)) < (Vista * Vista))) //si el jugador esta en rango visual por el eje X
        {
            if (((player.transform.position.y - transform.position.y) * (player.transform.position.y - transform.position.y)) < (Vista * Vista) / 2) //si el jugador esta en rango visual por el eje Y
            {
                presente = true;
            }
        }
        else
        {
            presente = false;
        }
        if (presente == false)
        {
            if (infoSuelo.collider == false)            //se le acaba el suelo
            {
                if (avanzandoIzquierda == true)
                {              //se le acaba el suelo mientras va a la izquierda
                    rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
                    transform.localScale = new Vector3(-dimension_x, dimension_y, 0);
                    avanzandoIzquierda = false;
                }
                else
                {                                       //se le acaba el suelo mientras va a la derecha
                    rb2d.velocity = new Vector2(-velocidad, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                    avanzandoIzquierda = true;
                }
            }
            else if (infoSuelo.collider == true)         //tiene suelo
            {
                if (avanzandoIzquierda == true)
                {              //si tiene suelo mientras va a la izquierda
                    rb2d.velocity = new Vector2(-velocidad, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                }
                else
                {                                       //si tiene el suelo mientras va a la derecha
                    rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
                    transform.localScale = new Vector3(-dimension_x, dimension_y, 0);
                }
            }
        }
        if (presente == true)
        {
            if (player.transform.position.x < transform.position.x)  //si el jugador esta a la izquierda
            {
                if (infoSuelo == true)
                {
                    rb2d.velocity = new Vector2(-velocidad * 2, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                }
                else if (infoSuelo == false)
                {
                    rb2d.velocity = new Vector2(-velocidad * 0, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                    avanzandoIzquierda = false;
                }
            }
            else if (player.transform.position.x > transform.position.x)  //si el jugador esta a la derecha
            {
                if (infoSuelo == true)
                {
                    rb2d.velocity = new Vector2(velocidad * 2, rb2d.velocity.y);
                    transform.localScale = new Vector3(-dimension_x, dimension_y, 0);

                }
                else if (infoSuelo == false)
                {
                    rb2d.velocity = new Vector2(velocidad * 0, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                    avanzandoIzquierda = true;
                }
            }
            else if (player.transform.position.x == transform.position.x)      //si el jugador esta donde el enemigo
            {
                if (avanzandoIzquierda == true)
                {
                    rb2d.velocity = new Vector2(-velocidad * 0, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                }
                else
                {
                    rb2d.velocity = new Vector2(velocidad * 0, rb2d.velocity.y);
                    transform.localScale = new Vector3(dimension_x, dimension_y, 0);
                }
            }
            //agregar una forma de detectar y seguir al jugador
            if (tiempoEntreAtaque <= 0)   //CD para los ataques
            {
                Collider2D[] enemigosDañados = Physics2D.OverlapCircleAll(PosAtaque.position, Rango, que_es_objetivo);
                for (int i = 0; i < enemigosDañados.Length; i++)
                {
                    if (enemigosDañados.Length > 0)
                    {
                        tiempoEntreAtaque = IniciartiempoEntreAtaque;
                        int num = Random.Range(1, 101);          //probabilidades
                        if (num < 90)            //ataque normal
                        {
                            enemigosDañados[i].GetComponent<player>().RecibeDaño(daño);
                        }
                        else if (num > 89)     //golpe critico
                        {
                            int critico = daño * 3;
                            enemigosDañados[i].GetComponent<player>().RecibeDaño(critico);
                            Debug.Log("Golpe Critico");
                        }
                    }
                }
            }
            else
            {
                tiempoEntreAtaque -= Time.deltaTime;
            }
        }
    } //este corchete cierra el void 

    public void RecibeDaño(int d)         //cuando recibe daño
    {
        salud -= d;
        Debug.Log("daño inflijido");
        if (salud <= 0)                      //si pierde toda su vida
        {
            Destroy(this.gameObject);            //muere *agreguen animaciones porfa*
        }
        float proporcion = (float)salud / (float)salud_inicial; //animacion de salud
        vida.fillAmount = proporcion;
    }
}
