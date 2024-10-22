using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
