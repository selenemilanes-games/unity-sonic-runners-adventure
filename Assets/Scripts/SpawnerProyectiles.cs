using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerProyectiles : MonoBehaviour
{ 
    public GameObject proyectil;
    
    void Start()
    {
        StartCoroutine(CrearProyectiles());
    }

    void Update()
    {
        
       
    }

    IEnumerator CrearProyectiles()
    {
        while (true)
        {
            GameObject nuevoProyectil = Instantiate(proyectil);
            nuevoProyectil.transform.position = this.transform.position;
            nuevoProyectil.transform.position = new Vector3(nuevoProyectil.transform.position.x, Random.Range(-2.3f, 2.70f), +10);

            int tiempoEspera = Random.Range(2, 5);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
