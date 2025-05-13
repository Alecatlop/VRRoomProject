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
    public bool ispressed;
    float horas = 5f;
    float minutos = 55f;
    float segundos = 43f;
    float speed = 40f;
    public Light luz;
    GameObject cielodia;
    GameObject cielonoche;
    int valor;

    public UnityEvent onPressed;

    // Start is called before the first frame update
    private void Start()
    {

        cielodia = GameObject.Find("Cielodia");
        cielonoche = GameObject.Find("Cielonoche");
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

        if (segundos > 59)
        {
            segundos = 0;
            minutos++;
        }

        if (minutos > 59)
        {
            minutos = 0;
            horas++;
        }

        if (horas > 23)
        {
            horas = 0;
        }

        // º grados / horas 1 360º / 24horas= 15º girar la luz en funcion de la hora
    }

    private void MostrarTiempoReal()
    {
        DateTime startTime = globaltime.GetStartDateTime();
        tiempo.text = startTime.Hour + " : " + startTime.Minute + " : " + startTime.Millisecond / 10;

        if (startTime.Millisecond > 59)
        {
            
        }
    }

    private void MostrarTiempoJuego()
    {
        tiempo.text = horas.ToString("00") +" : " + minutos.ToString("00") + " : " + ((int)segundos).ToString("00");
    }

    private void Apretado()
    {
        //cambiar tiempo virtual
        print("apretado");
        MostrarTiempoJuego();
    }

    private void NoApretado()
    {
        //cambiar tiempo real
        print("no apretado");
        MostrarTiempoReal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Button")
        {
            ispressed = !ispressed;
        }
    }
}
