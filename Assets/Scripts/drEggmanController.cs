using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drEggmanController : MonoBehaviour
{
    public int speed;
    public GameObject ring;
    public Transform Sonic;
    public AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tirarMonedas());
        StartCoroutine(escogerMovimiento());
        audios = GetComponents<AudioSource>();
        StartCoroutine(EggmanSays());
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            movimientoArriba();
        }
        /*print(collision.gameObject.GetComponent<SpriteRenderer>().sprite.name);*/
        
        if (collision.gameObject.tag == "Limite")
        {
            print("Eggman colisiona con límite");
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SonicBola")
        {
            tirarMuchasMonedas();
        }
    }

    public IEnumerator tirarMonedas()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            switch (Random.Range(0, 3))
            {
                case 0:
                    GameObject ring1 = Instantiate(ring);
                    ring1.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 3f)), this.transform.position.y - (Random.Range(0, 1f)));
                    GameObject ring2 = Instantiate(ring);
                    ring2.transform.position = this.transform.position;
                    GameObject ring3 = Instantiate(ring);
                    ring3.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 2f)), this.transform.position.y - (Random.Range(0, 2)));
                    ring3.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y - 2);
                    break;
                case 1:
                  GameObject ring4 = Instantiate(ring);
                  ring4.transform.position = this.transform.position;
                  break;
                case 2:
                    GameObject ring5= Instantiate(ring);
                    ring5.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 3f)), this.transform.position.y - (Random.Range(0, 1f)));
                    GameObject ring6 = Instantiate(ring);
                    ring6.transform.position = this.transform.position;
                    break;
            }
        }
    }

    private void tirarMuchasMonedas()
    {
        for (int i = 0; i <= 3; i++)
        {
            GameObject ring1 = Instantiate(ring);
            ring1.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 3f)), this.transform.position.y - (Random.Range(0, 1f)));
            ring1.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y-0.2f);
           
            GameObject ring2 = Instantiate(ring);
            ring2.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 2f)), this.transform.position.y - (Random.Range(0, 2)));
            ring2.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y - 2);
            
            GameObject ring3 = Instantiate(ring);
            ring3.transform.position = new Vector2(this.transform.position.x - (Random.Range(0, 3f)), this.transform.position.y - (Random.Range(0, 1f)));
            ring3.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y - 1);
        }
    }

    private IEnumerator escogerMovimiento()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            switch (Random.Range(0, 4))
            {
                case 0:
                    movimientoAbajo();
                    break;
                case 1:
                    movimientoArriba();
                    break;
                case 2:
                    movimientoIzquierda();
                    break;
                case 3:
                    movimientoDerecha();
                    break;
            }
        }
    }

    private void movimientoAbajo()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }

    private void movimientoArriba()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    private void movimientoIzquierda()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }

    private void movimientoDerecha()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    private IEnumerator EggmanSays()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            switch (Random.Range(0, 2))
            {
                case 0:
                    audios[0].Play(); //Muahahahaha
                    break;
                case 1:
                    audios[1].Play(); //World is mine
                    break;

            }
        }
    }
}
