using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedTocada : MonoBehaviour
{
    [SerializeField]
    Material material1;

    [SerializeField]
    Material material2;

    bool paredTocada = false;
    float tiempoParedTocada = 5f;

    void Start()
    {
        paredTocada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (paredTocada == true)
        {
            tiempoParedTocada = tiempoParedTocada-Time.deltaTime;
        }
        if (tiempoParedTocada < 0.0f)
        {
            gameObject.GetComponent<MeshRenderer>().material = material1;
            paredTocada = false;
        }
        if (paredTocada == false)
        {
            tiempoParedTocada = 5f;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        { 
            paredTocada = true;
            gameObject.GetComponent<MeshRenderer>().material = material2;
        }
    }
}
