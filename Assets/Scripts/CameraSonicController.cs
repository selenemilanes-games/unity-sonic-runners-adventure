using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSonicController : MonoBehaviour
{
    public Transform Sonic;
    float minX = 0;

    //public int camSpd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        //Cámara que avanzará a medida que avance el Sonic y no permitirá retroceder
        if (Sonic.transform.position.x > minX) minX = Sonic.transform.position.x;
        this.transform.position = new Vector3(minX, this.transform.position.y, -10);

        //Cámara que puede ir tanto hacia adelante como hacia atrás
        /*if(Sonic.transform.position.x>minX)minX = Sonic.transform.position.x;
        this.transform.position = new Vector3(Sonic.transform.position.x, this.transform.position.y, -10);*/

        //Camara que solo puede ir hacia adelante a partir del punto de inicio de la partida, pero se puede volver atrás
        //hasta el punto de inicio
        /* if (Sonic.transform.position.x>=minX)
         {
             this.transform.position = new Vector3(Sonic.transform.position.x, this.transform.position.y, -10);
         }*/

        //Esta cámara se mueve teniendo al Sonic como centro. Si el Sonic salta, la cámara salta támbién
        //El siguiente código lo que hace es mover el objeto de su posición actual a la posición de SonicPosition en un tiempo
        //determinado y con una velocidad determinada por "camSpd":
        /*Vector3 SonicPosition = new Vector3(Sonic.transform.position.x, Sonic.transform.position.y, -10);
        this.transform.position = Vector3.Lerp(this.transform.position, SonicPosition, Time.deltaTime*camSpd);*/
        //El deltaTime es el tiempo que transcurre entre un fotograma del juego y el siguiente
    }
}
