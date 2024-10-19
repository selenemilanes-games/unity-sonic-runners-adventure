using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBolaController : MonoBehaviour
{
    
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Force); 
        //AddTorque(velocidad, fuerza que se le aplica utilizando su masa)
    }

 
    void Update()
    {
       
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Limite")
        {
            Destroy(this.gameObject);
        }
    }
}
