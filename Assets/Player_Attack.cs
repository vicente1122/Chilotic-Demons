using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private float tiempoEntreAtaque;
    public float IniciartiempoEntreAtaque;

    public KeyCode AtaqueMele;

    public Transform PosAtaque;
    public float rango_mele;
    public LayerMask que_es_enemigo;
    public int daño;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEntreAtaque <= 0)   //CD para los ataques
        {
            if (Input.GetKey(AtaqueMele))
            {
                Collider2D[] enemigosDañados = Physics2D.OverlapCircleAll(PosAtaque.position, rango_mele, que_es_enemigo);
                for(int i = 0; i<enemigosDañados.Length; i++)
                {
                    enemigosDañados[i].GetComponent<Enemigo>().RecibeDaño(daño);
                }
            }
            tiempoEntreAtaque = IniciartiempoEntreAtaque;
        }
        else
        {
            tiempoEntreAtaque -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
