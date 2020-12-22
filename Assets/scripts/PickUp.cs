using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private inventario inventario;
    public GameObject itemButtom;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<inventario>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventario.slots.Length; i++)
            {
                if (inventario.isFull[i] == false)
                {
                    inventario.isFull[i] = true;
                    Instantiate(itemButtom, inventario.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }

            }
        }

    }
}