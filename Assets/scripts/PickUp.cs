using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private inventario inventario1;
    public GameObject itemButtom;
    void Start()
    {
        inventario1=GameObject.FindGameObjectWithTag("Player").GetComponent<inventario>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventario1.slots.Length; i++)
            {
                if(inventario1.isFull[i]==false)
                {
                    inventario1.isFull[i]=true;
                    Instantiate(itemButtom,inventario1.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
                
            }
        }

    }
}
