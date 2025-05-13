using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public TextMeshPro textopuntos;
    int puntuacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            puntuacion++;

            if (puntuacion == 1)
            {
                textopuntos.text = (puntuacion + " Punto");

            }
            else textopuntos.text = (puntuacion + " Puntos");
        }
       
    }
}
