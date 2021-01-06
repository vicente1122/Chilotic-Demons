using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sistema_vida : MonoBehaviour
{
    public int salud;  //total de vida, este se cambia
    public Image IMGvida;    // Para desplegar la vida de forma visible
    private int salud_inicial; //total de vida inicial, no se cambia
    // Start is called before the first frame update
    void Start()
    {
        salud_inicial = salud;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibeDaño(int d)         //cuando recibe daño
    {
        salud -= d;
        Debug.Log("daño inflijido");
        if (salud <= 0)                      //si pierde toda su vida
        {
            Destroy(this.gameObject);            //muere *agreguen animaciones porfa*
        }
        float proporcion = (float)salud / (float)salud_inicial;
        IMGvida.fillAmount = proporcion;
    }
}
