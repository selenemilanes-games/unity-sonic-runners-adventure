using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBolaController : MonoBehaviour
{

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            print("Enemigo muerto");
        }

        if (collision.tag == "SSVoladorEnemigo")
        {
            collision.GetComponent<SSVoladorController>().speed *= 2;
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            collision.GetComponent<SSVoladorController>().enfadado();
            collision.GetComponent<SSVoladorController>().vida--;
            Destroy(this.gameObject);
            if (collision.GetComponent<SSVoladorController>().vida==0)
            {
                Destroy(collision.gameObject);
            }
            print("Enemigo muerto");
        }
    }
}
