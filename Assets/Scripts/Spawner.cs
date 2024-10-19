using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public GameObject[] enemigos;
    
    void Start()
    {
        StartCoroutine(CrearEnemigo());
    }

    void Update()
    {
        
       
    }

    IEnumerator CrearEnemigo()
    {
        while (true)
        {
            GameObject newEnemigo = Instantiate(enemigos[Random.Range(0,0)]);
            newEnemigo.transform.position = this.transform.position;
            newEnemigo.transform.position = new Vector3(newEnemigo.transform.position.x, newEnemigo.transform.position.y, +10);

            //Esto es lo que esperas. Es lo mismo que un Thread.sleep
            int tiempoEspera = Random.Range(4, 8);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
