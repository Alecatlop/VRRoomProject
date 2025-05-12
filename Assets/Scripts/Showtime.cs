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
    float horas = 22f;
    float minutos = 55f;
    float segundos = 43f;
    float speed = 40f;
    public Light luz;
    int[] noche;
    GameObject cielodia;
    GameObject cielonoche;

    public UnityEvent onPressed;

    // Start is called before the first frame update
    private void Start()
    {

        noche[0] = 22;
        noche[1] = 23;
        noche[2] = 00;
        noche[3] = 01;
        noche[4] = 02;
        noche[5] = 03;
        noche[6] = 04;
        noche[7] = 05;
        noche[8] = 06;
        noche[9] = 07;

        cielodia = GameObject.Find("Cielodia");
        cielonoche = GameObject.Find("Cielonoche");
    }

    // Update is called once per frame
    void Update()
    {
        print(luz.intensity);
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

        for (int i = 0; i < noche.Length; i++)
        {
            if (i == horas)
            {
                luz.intensity = 0;
                cielodia.SetActive(false);
                cielonoche.SetActive(true);
            }
            else luz.intensity = 3; cielodia.SetActive(true); cielonoche.SetActive(false);

        }
    }

    private void MostrarTiempoReal()
    {
        DateTime startTime = globaltime.GetStartDateTime();
        tiempo.text = startTime.Hour + " : " + startTime.Minute + " : " + startTime.Millisecond / 10;
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
