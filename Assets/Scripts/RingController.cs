using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RingController : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
    }

    
    void Update()
    {
        if (this.GetComponent<Transform>().position.y > 3)
        {
            movimientoAbajo();
        }

    }
    void OnBecameInvisible() //Si el objeto sale fuera de la cámara, se elimina
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            movimientoArriba();
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    private void movimientoArriba()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
    private void movimientoAbajo()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
    }

    public void ringCogido()
    {
        this.GetComponent<AudioSource>().Play();
    }

}
