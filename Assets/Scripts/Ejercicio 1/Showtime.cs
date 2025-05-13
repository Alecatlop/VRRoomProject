using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class Showtime : MonoBehaviour
{
    public TextMeshPro tiempo;
    public Reloj globaltime;
    bool ispressed;
    float horas = 8f;
    float minutos = 0f;
    float segundos = 0f;
    float hora;
    float minuto;
    float segundo;
    public float speed = 40f;
    public Light luzvirtual2;
    GameObject luzvirtual;
    public Light luzreal2;
    GameObject luzreal;

    public UnityEvent onPressed;

    // Start is called before the first frame update
    private void Start()
    {
        luzvirtual = GameObject.Find("luzvirtual");
        luzreal = GameObject.Find("luzreal");

        ispressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ispressed == true)
        {
            Apretado();
        }
        else NoApretado();

        segundos += Time.deltaTime * speed;
        segundo += Time.deltaTime;

        if (segundos > 59)
        {
            segundos = 0;
            minutos++;
        }

        if (minutos > 59)
        {
            minutos = 0;
            horas++;
            luzvirtual2.transform.Rotate(transform.rotation.x + 15, 0, 0);
        }

        if (horas > 23)
        {
            horas = 0;
        }

        if (segundo > 59)
        {
            segundo = 0;
            minuto++;
        }

        if (minuto > 59)
        {
            minuto = 0;
            hora++;
            luzreal2.transform.Rotate(transform.rotation.x + 15, 0, 0);
        }

    }

    private void MostrarTiempoReal()
    {
        DateTime startTime = globaltime.GetStartDateTime();
        hora = startTime.Hour;
        minuto = startTime.Minute;
        segundo = startTime.Millisecond;
        tiempo.text = hora + " : " + minuto + " : " + ((int)segundo);
    }

    private void MostrarTiempoVirtual()
    {
        tiempo.text = horas.ToString("00") +" : " + minutos.ToString("00") + " : " + ((int)segundos).ToString("00");

    }

    private void Apretado()
    {
        //cambiar tiempo virtual
        MostrarTiempoVirtual();
        luzvirtual.SetActive(true);
        luzreal.SetActive(false);
    }

    private void NoApretado()
    {
        //cambiar tiempo real
        MostrarTiempoReal();
        luzreal.SetActive(true); 
        luzvirtual.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Button")
        {
            ispressed = !ispressed;
        }
    }

}
