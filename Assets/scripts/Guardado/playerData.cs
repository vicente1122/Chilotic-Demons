using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class playerData
{
    public string nivel;
    public int vida;
    public float[] ubicacion;
    public bool esta_lleno0;
    public bool esta_lleno1;
    public bool esta_lleno2;
    public string[] que_tiene;

    public playerData(player Jugador)
    {
        nivel = SceneManager.GetActiveScene().name;
        vida = Jugador.salud;
        ubicacion = new float[3];
        ubicacion[0] = Jugador.transform.position.x;
        ubicacion[1] = Jugador.transform.position.y;
        ubicacion[2] = Jugador.transform.position.z;
        Debug.Log("llegaste hasta aca");
        esta_lleno0 = Jugador.inventario.isFull[0];
        esta_lleno1 = Jugador.inventario.isFull[1];
        esta_lleno2 = Jugador.inventario.isFull[2];
        que_tiene = new string[3];
        if (esta_lleno0 == true)
        {
            que_tiene[0] = Jugador.inventario.slots[0].transform.GetChild(1).gameObject.name;
            Debug.Log(Jugador.inventario.slots[0].transform.GetChild(1).gameObject.name);
        }
        if (esta_lleno1 == true)
        {
            que_tiene[1] = Jugador.inventario.slots[1].transform.GetChild(1).gameObject.name;
            Debug.Log(Jugador.inventario.slots[1].transform.GetChild(1).gameObject.name);
        }
        if (esta_lleno2 == true)
        {
            que_tiene[2] = Jugador.inventario.slots[2].transform.GetChild(1).gameObject.name;
            Debug.Log(Jugador.inventario.slots[2].transform.GetChild(1).gameObject.name);
        }
    }
}