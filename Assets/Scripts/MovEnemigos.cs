using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigos : MonoBehaviour
{
    [SerializeField]
    public float velEnemigo;

    [SerializeField]
    public float rotacionEnemigo;

    void Update()
    {
        transform.Translate(Vector3.forward*velEnemigo*Time.deltaTime);
    }
    public void OnCollisionEnter(Collision collision)
    {
        transform.Rotate(0,rotacionEnemigo,0);
    }
}
