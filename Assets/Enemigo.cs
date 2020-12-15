﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float dimension_x;    //para evitar problemas de orientacion y asignar las dimensiones
    public float dimension_y;
    public int salud;  //total de vida
    public float velocidad;
    public float distancia;     //a que distancia detecta el suelo
    private bool avanzandoIzquierda = true;
    private Rigidbody2D rb2d;
    public Transform deteccionSuelo;

    //variables de combate abajo
    public float Vista; //rango visual
    public float Rango; //rango de ataque
    public int daño; //daño MINIMO que puede hacer
    public LayerMask que_es_objetivo; //se asigna quien califica como enemigo
    public Transform PosAtaque; //se donde viene el ataque
    private float tiempoEntreAtaque; //cuenta el tiempo que pasa
    public float IniciartiempoEntreAtaque; //cuenta el tiempo que pasa entre ataques
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(deteccionSuelo.position, Vector2.down, distancia);   //sensor de si se le acaba el suelo


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

        if (tiempoEntreAtaque <= 0)   //CD para los ataques
        {
            Collider2D[] enemigosDañados = Physics2D.OverlapCircleAll(PosAtaque.position, Rango, que_es_objetivo);
            for (int i = 0; i < enemigosDañados.Length; i++)
            {
                enemigosDañados[i].GetComponent<player>().RecibeDaño(daño);
            }
            tiempoEntreAtaque = IniciartiempoEntreAtaque;
        }
        else
        {
            tiempoEntreAtaque -= Time.deltaTime;
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
    }
}