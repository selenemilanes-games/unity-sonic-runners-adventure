using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSVoladorController : MonoBehaviour
{
    public int speed = 3;
    public int vida = 3;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Transform>().position.y > 3)
        {
            movimientoAbajo();
        }
     
        if (this.transform.position.x < -12)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            movimientoArriba();
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

    public void enfadado()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0);
        this.GetComponent<AudioSource>().Play();
    }
}
