using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenMusica : MonoBehaviour
{
    public AudioSource fuente;
    public Slider deslizadorVol;
    private float volumen = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        //fuente = GetComponent<AudioSource>();
        volumen = PlayerPrefs.GetFloat("volum");
        fuente.volume = volumen;
        deslizadorVol.value = volumen;
    }

    // Update is called once per frame
    private void Update()
    {
        fuente.volume = volumen;
        PlayerPrefs.SetFloat("volum", volumen);
    }
    public void actualizarVolumen(float vol)
    {
        volumen = vol;
    }
}
