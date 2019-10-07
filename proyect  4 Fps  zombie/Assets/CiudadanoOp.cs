 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.enemy;




namespace Npc
{
    namespace ally
    {
        public class CiudadanoOp : NpcEstado
        {
            public CosasCiudadanos datoCiudadanos; // variable de la estructura
            public GameObject JugadorObjeto;
            public GameObject textc; //texto para la pantalla del canvas
            CosasZombie zombicosas; // variable de la estrutura de zombi
            

            void Awake()
            {
                int darnombre = Random.Range(0, 20);            //obtener ramdo de los nombres depues asignarlas 
                datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)darnombre;
                datoCiudadanos.edadgente = Random.Range(15, 101);   //obtener random de las edades y despues asignarls 
                textc = GameObject.Find("Main Camera"); // busca la camara y la asigna como como la variable textc
            }

            void Start()
            {
                   
                StartCoroutine("Cambioestado");     // corutina para el cambio de estado 
                 JugadorObjeto = FindObjectOfType<Hero>().gameObject; // el ciudadano detecta al hero para asi poder pasarle el mensaje
            }
            Vector3 direc;
            void OnDrawGizmos()
            {
                Gizmos.DrawLine(transform.position, transform.position - direc);
            }


            public void OnCollisionEnter(Collision collision) // al colicionar el aldeano con un zombi este se transforma de zombi
            {
                if (collision.transform.name == "Zombi")
                {
                   
                    transform.name = "Zombi"; // su nombre cambia
                    
                    ZombieOP cambioedad = gameObject.AddComponent<ZombieOP>();//se le agrega la edad
                    cambioedad.datosZombi = (CosasZombie) gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;//aqui el zombiealdeano sigue teniendo su edad
                   
                    Destroy(this.gameObject.GetComponent<CiudadanoOp>());//por ultimo se le elimina el scrit de cidadano
                   

                   

                }
            }


            
            void Update()
            {
                float distmin = 5;                          ///-------------corre de los zombie------------\\\
                GameObject zombimascerca = null;

                foreach (var item in FindObjectsOfType<ZombieOP>())         //ahora todos los cidadanos van a huir de los zombies
                {
                    float tempdist = Vector3.Distance(this.transform.position, item.transform.position);
                    if (tempdist <= distmin)
                    {
                        distmin = tempdist;
                        zombimascerca = item.gameObject;
                    }
                }
                 Vector3 mivector = JugadorObjeto.transform.position - transform.position;
                 float distanciajugador = mivector.magnitude;
                if (zombimascerca != null)                                          ///-----si hay zombie cerca todos los zombies correran----\\\
                {
                    direc = Vector3.Normalize(zombimascerca.transform.position + transform.position);
                    transform.position += direc * 0.1f;
                }
                 
                 else if(distanciajugador <= 5.0f)      // si es jugador esta cerca de los ciudadanos este le aparecera un mensaje en la pantalla 
                 {
                       textc.GetComponent<Generador>().ctext.text = "HOOOOOLA SOY  "+datoCiudadanos.genteNombres + "Y TENGO  "+ datoCiudadanos.edadgente;
                 }
                 else if (distanciajugador >= 3.0f) // al alejar el jugador este el mensaje desaparecera de la pantalla
                    {
                         textc.GetComponent<Generador>().Ztext.text = "";
                    }
                else                                       //cuando nadie esta cerca de los ciudadanos este entra en sus estado normales 
                {
                    Statemovi();                   
                }

            }
            

        }




        public struct CosasCiudadanos       //estructura de los cuidadanos
        {
            public enum Nombres
            {
                stubbs,
                rob,
                toreto,
                pequeñotim,
                doncarlos,
                carlosII,
                carlosI,
                sergio,
                stevan,
                tutiaentanga,
                panzerottedelsena,
                cj,
                haytevoysampedro,
                sanpeludo,
                alexisdelpeludoII,
                putoalexis,
                jason,
                andrey,
                atreus,
                artion,
                kratos,
                zeus,
                loki,
                sam,
                wilson,
                elbrayan,
                venites,
                sampedro,
            }
            public Nombres genteNombres;

           
            public int edadgente;

            public static explicit operator CosasZombie(CosasCiudadanos dgente) //funcion para compartir una la edades del ciudadanos al zombie
            {
                CosasZombie Szombie = new CosasZombie();
                Szombie.edadzombi = dgente.edadgente;
                return Szombie;
            }
        }
    }
}

   

    

