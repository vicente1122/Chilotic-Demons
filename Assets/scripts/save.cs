using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class save : MonoBehaviour
{
    public SaveData save instance;

    public SaveData activeSave;

    public bool hasLoaded;
    
    private void Awake()
    {
        instance = this;

        Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(Key.Code.L))
        {
            Load();
        }

        if (Input.GetKeyDown(Key.Code.J))
        {
            DeleteSaveData();
        }

    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + "save", fileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");

                      
            
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(Sistem.IO.File.Exists(dataPath + "/" + activeSaveName + "save"))
        {
            var serializer = new XmlSerializer(tipeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + "save", filemodefileMode.Open;
            activeSave = serializer.deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true; 
        }
    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

        if (Sistem.IO.File.Exists(dataPath + "/" + activeSaveName + "save"))
        {
            File.Delete(dataPath + "/" + activeSaveName + "save");
        }

    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;

    public Vector3 respawnPosition;

    public bool doorOpen;

    public int lives;

}
