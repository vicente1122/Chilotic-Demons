using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaMuerto : MonoBehaviour
{
    public player player;
    public GameObject UDiedText;
    public MenuPausa MenuPausa;
    public GameObject UI;
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo=-999f;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("menuvolver",10f);
        if(MenuPausa.PausedGame)
        {
            UDiedText.gameObject.SetActive(false);
        }
        if (player.salud<=0)
        {
            UDiedText.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
            tiempo=10f;
        }
    }
    void menuvolver()
    {
        MenuPausa.LoadMenu();
    }
}
