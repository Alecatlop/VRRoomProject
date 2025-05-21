using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Vector3 inicio;

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
        if (other.tag == "Respawn" )
        {
            this.transform.position = inicio;
        }
    }

}
