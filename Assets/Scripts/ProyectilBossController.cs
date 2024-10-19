using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBossController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnBecameInvisible() //Si el objeto sale fuera de la cámara, se elimina
    {
        Destroy(gameObject);
    }

}
