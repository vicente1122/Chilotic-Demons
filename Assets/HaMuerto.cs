using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaMuerto : MonoBehaviour
{
    public player player;
    public GameObject UDiedText;
    public MenuPausa MenuPausa;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(MenuPausa.PausedGame)
        {
            UDiedText.gameObject.SetActive(false);
        }
        if (player.salud<=0)
        {
            UDiedText.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
            
            Invoke("menuvolver",10f);
        }
    }
    void menuvolver()
    {
        MenuPausa.LoadMenu();
    }
}
