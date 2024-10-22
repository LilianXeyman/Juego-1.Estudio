using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepot : MonoBehaviour
{
    public Transform Destino;

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Destino.position;
        }
    }
}
