using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void guardarJugador(player Jugador)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string direccion = Application.persistentDataPath + "/jugador.krg";
        FileStream stream = new FileStream(direccion, FileMode.Create);
        playerData data = new playerData(Jugador);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static playerData CargarJugador()
    {
        string direccion = Application.persistentDataPath + "/jugador.krg";
        if (File.Exists(direccion))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(direccion, FileMode.Open);
            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("guardado no encontrado" + direccion);
            return null;
        }
    }
}