using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.ally;




namespace Npc
{
    namespace enemy
    {
        public class ZombieOP : NpcEstado
        {
            public CosasZombie datosZombi;                                // ----------- structura de gustos y color ------------- \\
            public GameObject textoz;
            void Awake()
            {
                datosZombi.colorEs = (CosasZombie.ColorZombie)Random.Range(0, 3); //ramdon de los colores delos zombies
                int dargusto = Random.Range(0, 5);  //random de los gusto
                datosZombi.sabroso = (CosasZombie.Gustos)dargusto; //asigancion de los rangos de los gustos
                datosZombi.edadzombi = Random.Range(15, 101);//aqui odtiene la edad de las edades
                textoz = GameObject.Find("Main Camera");//
            }
            public void cam()//funcion para dar color a los zombies que se transforman
            {

                int cambiocolor = Random.Range(1, 3);
                switch (cambiocolor)
                {
                    case 1:
                        gameObject.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case 2:
                        gameObject.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case 3:
                        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }
            }
            Vector3 direction;
            void OnDrawGizmos() //el gizmo muestra la direccion en la que se mueve el zombi
            {
                Gizmos.DrawLine(transform.position, transform.position + direction);
            }


            public GameObject JugadorObjeto;
            public GameObject NpcGente;
            void Start()
            {

                StartCoroutine("Cambioestado"); // inicio de corutina

                JugadorObjeto = FindObjectOfType<Hero>().gameObject;//el zombie ya reconoce al hero como un objeto


            }



            void Update()
            {

                float distanciaMin = 5;
                GameObject ciudadanoMasCercano = null;

                foreach (var ciudadano in FindObjectsOfType<CiudadanoOp>()) //los zombies ya saben a quien perseguir 
                {
                    float tempDist = Vector3.Distance(this.transform.position, ciudadano.transform.position);

                    if (tempDist < distanciaMin)
                    {
                        distanciaMin = tempDist;
                        ciudadanoMasCercano = ciudadano.gameObject;
                    }
                }

                Vector3 mivector = JugadorObjeto.transform.position - transform.position;
                float distanciajugador = mivector.magnitude;

                if (ciudadanoMasCercano != null) //sigbnifica que hay un ciudadano cerca 
                {
                    direction = Vector3.Normalize(ciudadanoMasCercano.transform.position - transform.position);
                    transform.position += direction * 2.5f / datosZombi.edadzombi;
                }
                else if (distanciajugador <= 3.0f) // aqui persigue alhero y genera el mensaje en la pantalla 
                {
                    direction = Vector3.Normalize(JugadorObjeto.transform.position - transform.position);
                    transform.position += direction * 0.1f;
                    Debug.Log("waaarrrr " + "quiero comer " + datosZombi.sabroso + "" + datosZombi.edadzombi);
                    textoz.GetComponent<Generador>().Ztext.text = "waaarrrr " + "quiero comer " + datosZombi.sabroso;


                }
                else if (distanciajugador >= 3.0f) // si el hero se aleja de los zombies el mensaje desaparese
                {
                    textoz.GetComponent<Generador>().Ztext.text = "";
                }
                else // no hay un ciudadano cerca o el hero el zombie entra en alos estado normales
                {
                    Statemovi();

                }

            }

        }

    }

    public struct CosasZombie   //la estrutura de los zombie los cuals contiene los enum de el 
    {

        public enum Gustos
        {
            Brazos,
            Piernas,
            Huesitos,
            Ojito,
            corazoncito
        };
        public Gustos sabroso;

        public enum ColorZombie
        {
            magenta,
            green,
            cyan
        };

        public ColorZombie colorEs;

        public int edadzombi;
    }



    








}




