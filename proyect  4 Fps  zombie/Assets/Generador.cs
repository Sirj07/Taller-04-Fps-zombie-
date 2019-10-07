using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Npc.ally;
using Npc.enemy;
using Npc;
using UnityEngine.SceneManagement;



public class Generador : MonoBehaviour
{
    public GameObject ZombieMesh;
    public GameObject Gente;
    public GameObject Hero;
    CosasZombie datoszombi;
    CosasCiudadanos datoCiudadanos;    
    readonly int minimo;
    const int maximo = 25;
    int cantbody;
    public Text enemy;
    public Text ally;
    public Text Ztext;
    public Text ctext;
    public GameObject Game_over;
    bool empezar = false;


    void restar()
    {
        SceneManager.LoadScene(0);
    }



    System.Random rn = new System.Random(); // random de system

    public Generador()
    {
        minimo = rn.Next(5, 15);    //rango de creación usando el random de system
        
    }

    void Start()
    {                                 // generador de NPC
        cantbody = rn.Next(minimo, maximo);
        
        for (int i = 0; i < cantbody; i++)
        {
            if (rn.Next(0,2)==0)
            {           
                // generador de zombis
                ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);  // creacion de primityve
                
                ZombieMesh.AddComponent<ZombieOP>();
                
                datoszombi = ZombieMesh.GetComponent<ZombieOP>().datosZombi;
                                                                                            //asignacion de colores de los zombies
                switch (datoszombi.colorEs)
                {
                    case CosasZombie.ColorZombie.magenta:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case CosasZombie.ColorZombie.green:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case CosasZombie.ColorZombie.cyan:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }
                

                Vector3 pos = new Vector3(rn.Next(-10, 10), 0, rn.Next(-10, 10));           //creacion de la pocicion de los zombies

               
                ZombieMesh.transform.position = pos;
                
               ZombieMesh.AddComponent<Rigidbody>();
                
               ZombieMesh.name = "Zombi";
            }
            else // generador de ciudadanos \\
            {
                Gente = GameObject.CreatePrimitive(PrimitiveType.Cube); //creacion de primitives 
                Gente.AddComponent<CiudadanoOp>();//añadiendo el scrit de los ciudadnos
                Vector3 po = new Vector3(rn.Next(-20, 10), 0, rn.Next(10, 10));//creacion de la pocicion de los ciudadnos
                Gente.transform.position = po;
                Gente.AddComponent<Rigidbody>();
                Gente.name = "Gente";
            }
        }
       
        // generador hero \\
        Hero = GameObject.CreatePrimitive(PrimitiveType.Cube);  //crecionde un primitive de para el hero
        Hero.AddComponent<MovimientoTeclado>();         //agregar scrit del teclado
        Hero.AddComponent<Hero>();//agrega el scrit del hero
        Hero.AddComponent<Camera>();    //agrega la camara
        Hero.AddComponent<Rigidbody>(); // agrega el ridibody
        Hero.name = "Hero";

            
       int numzombie = 0;
       int numaldeanos = 0;

       // texto canvas \\
        foreach (ZombieOP enemy in Transform.FindObjectsOfType<ZombieOP>()) //busca todos los objetos que tengan el scrit de zombies y despues los agrega aun contador el cual le pasa la informacion canvas
        {
           numzombie++;
        }

        foreach (CiudadanoOp ally in Transform.FindObjectsOfType<CiudadanoOp>())//busca todos los objetos que tengan el scrit de ciudadanos y despues los agrega aun contador el cual le pasa la informacion canvas
        {
            numaldeanos++;
        }
        Debug.Log("contador"+numzombie);
        ally.text="aldeanos: "+numaldeanos; //asignacion de el texto de canvas 
        enemy.text="zombies: "+numzombie;
      
    }
     void Update()// reinicio
    {
        if (Input.GetKey(KeyCode.R))
        {
            empezar = true;
        }

        if (empezar == true)
        {
            restar();
        }


    }
}
