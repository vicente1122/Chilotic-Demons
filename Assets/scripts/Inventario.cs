using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject selectedSlot;
    public KeyCode Next;
    public KeyCode Prev;
    private int selectedSlotInt=0;
        void Start()
    {
        Instantiate(selectedSlot,slots[0].transform,false);
        Instantiate(selectedSlot,slots[1].transform,false);
        Instantiate(selectedSlot,slots[2].transform,false);
        //slots[0].transform.GetChild(0).gameObject.SetActive(false);
        slots[1].transform.GetChild(0).gameObject.SetActive(false);
        slots[2].transform.GetChild(0).gameObject.SetActive(false);
    }

   
    void FixedUpdate()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(false);

            
            if (selectedSlotInt+1>slots.Length-1)
            {
                selectedSlotInt=0;
            }
            else
            {
                selectedSlotInt+=1;;
            }
            Debug.Log(selectedSlotInt);
            slots[selectedSlotInt].transform.GetChild(0).gameObject.SetActive(true);
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
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
}
