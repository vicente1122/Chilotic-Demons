using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float dimension_x;    //para evitar problemas de orientacion
    public float dimension_y;
    public int salud;  //total de vida
    public float velocidad;
    public float distancia;     //a que distancia detecta el suelo
    private bool avanzandoIzquierda = true;
    private Rigidbody2D rb2d;
    public Transform deteccionSuelo;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D infoSuelo = Physics2D.Raycast(deteccionSuelo.position, Vector2.down, distancia);   //como el sensor de si se le acaba el suelo
        
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
    public void RecibeDaño(int d)         //cuando recibe daño
    {
        salud -= d;
        Debug.Log("daño recibido");
        if (salud <= 0)                      //si pierde toda su vida
        {
            Destroy(this.gameObject);            //muere
        }
    }
}
