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

    public playerData(player Jugador)
    {
        nivel = SceneManager.GetActiveScene().name;
        vida = Jugador.salud;
        ubicacion = new float[3];
        ubicacion[0] = Jugador.transform.position.x;
        ubicacion[1] = Jugador.transform.position.y;
        ubicacion[2] = Jugador.transform.position.z;
    }
}