using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;
using Npc.enemy;
using Npc;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hero : MonoBehaviour
{
    CosasZombie datosZombi;
    CosasCiudadanos datosciudadanos;

    //CosasCiudadanos datoCiudadanos;

     public GameObject muerto;

    public void Awake()
    {
        muerto = GameObject.Find("dead"); //buscar el  game over canvas 
        muerto.SetActive(false);  // lo  desactiva por que  esta  activado 
    }

    bool morir = false;
    
    public void OnCollisionEnter(Collision collision)         
    {
        if (collision.transform.name == "Zombi") 
        {
            muerto.SetActive(true);

             morir = true;
            Debug.Log("Presionar tecla R para reinicio ");

        }


        if (collision.transform.name == "Gente")
        {
            datosciudadanos = collision.gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;
            Debug.Log("Hola soy " + datosciudadanos.genteNombres + " y tengo " + datosciudadanos.edadgente);
        }
    }

    public void Update()
    {
        if (morir==true)
        {
            Destroy(this.gameObject);
        }

        
    }
    




}
