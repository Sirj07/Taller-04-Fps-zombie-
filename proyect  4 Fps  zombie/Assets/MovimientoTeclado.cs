using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimientoTeclado : MonoBehaviour
{
    public float Velocidad;
    float mouseX;
    public readonly float ve;
    System.Random VR = new System.Random();

    public MovimientoTeclado()
    {
        ve = (float)VR.NextDouble()*5;
    }




     void Start()
     {
        //Velocidad = VR.Next(ve);

        Debug.Log(ve);
     }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * ve / 20;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * ve / 20;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * ve / 20;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * ve / 20 ;

        }
       

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
