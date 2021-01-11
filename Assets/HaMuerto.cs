using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaMuerto : MonoBehaviour
{
    public player player;
    public GameObject UDiedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.salud<=0)
        {
            UDiedText.gameObject.SetActive(true);
        }
    }
}
