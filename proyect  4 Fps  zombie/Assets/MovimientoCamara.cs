using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
       void Start()
    {
        // transform.eulerAngles = new Vector3(30, 0, 0);
    }

    float mouseX;
    float mouseY;
    public bool InvertiVista;
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        if (InvertiVista)
        {
            mouseY += Input.GetAxis("Mouse Y");
        }
        else
        {
            mouseY -= Input.GetAxis("Mouse Y");
        }

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        if (mouseY >= 45f)
        {
            mouseY = 45f;
        }
        if (mouseY <= -45f)
        {
            mouseY = -45;
        }
    }
}
