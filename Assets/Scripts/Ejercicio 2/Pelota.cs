using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Vector3 inicio;
    public TextMeshPro textopuntos;
    int puntuacion = 0;

    // Start is called before the first frame update
    void Start()
    {
         inicio = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Room_Modern")
        {
            this.transform.position = inicio;
        }

        if (other.name == "Bin_Round_Brown")
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
