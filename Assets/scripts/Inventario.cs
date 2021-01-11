using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario : MonoBehaviour
{
    public GameObject hacha;
    public GameObject pocion;
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject selectedSlot;
    public KeyCode Next;
    public KeyCode Prev;
    public KeyCode pause;
    public GameObject inventario1;
    public int selectedSlotInt=0;
    public MenuPausa MenuPausa;

    void Start()
    {
        Instantiate(selectedSlot,slots[0].transform,false);
        Instantiate(selectedSlot,slots[1].transform,false);
        Instantiate(selectedSlot,slots[2].transform,false);
        //slots[0].transform.GetChild(0).gameObject.SetActive(false);
        slots[1].transform.GetChild(0).gameObject.SetActive(false);
        slots[2].transform.GetChild(0).gameObject.SetActive(false);
        inventario1.gameObject.SetActive(true);
    }

   
    void Update()
    {
        //if(Input.GetKeyDown(pause))
        /*if(isFull[selectedSlotInt])
        {
            Debug.Log(slots[selectedSlotInt].transform.GetChild(1));
        }¨*/
        

        if(MenuPausa.PausedGame||MenuPausa.leyendoNota)
        {
            inventario1.gameObject.SetActive(false);            
        }
        else
        {
            inventario1.gameObject.SetActive(true);
        }
        
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(Next))
        {
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(false);

            
            if (selectedSlotInt+1>slots.Length-1)
            {
                selectedSlotInt=0;
            }
            else
            {
                selectedSlotInt+=1;
            }
            Debug.Log(selectedSlotInt);
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(true);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(Prev))
        {
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(false);
            
            if (selectedSlotInt-1<0)
            {
                selectedSlotInt=slots.Length-1;
                Debug.Log(selectedSlotInt);
            }
            else
            {
                selectedSlotInt-=1;
            }
            Debug.Log(selectedSlotInt);
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void CargarInventario()
    {
        playerData data = SaveSystem.CargarJugador();
        if (data.esta_lleno0 == true)
        {
            isFull[0] = true;
        }
        if (data.esta_lleno1 == true)
        {
            isFull[1] = true;
        }
        if (data.esta_lleno2 == true)
        {
            isFull[2] = true;
        }

   ;
        if (data.esta_lleno0 == true)
        {
            if (data.que_tiene[0] == "HachaButtom(Clone)")
            {
                Instantiate(hacha, slots[0].transform);
            }
            else if (data.que_tiene[0] == "healthButtom(Clone)")
            {
                Instantiate(pocion, slots[0].transform);
            }
        }

        if (data.esta_lleno1 == true)
        {
            if (data.que_tiene[1] == "HachaButtom(Clone)")
            {
                Instantiate(hacha, slots[1].transform);
            }
            else if (data.que_tiene[1] == "healthButtom(Clone)")
            {
                Instantiate(pocion, slots[1].transform);
            }
        }
        if (data.esta_lleno2 == true)
        {
            if (data.que_tiene[2] == "HachaButtom(Clone)")
            {
                Instantiate(hacha, slots[2].transform);
            }
            else if (data.que_tiene[2] == "healthButtom(Clone)")
            {
                Instantiate(pocion, slots[2].transform);
            }
        }
    }
}
