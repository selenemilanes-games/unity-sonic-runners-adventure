using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drEggmanBossController : MonoBehaviour
{
    public int speed;
    public AudioSource[] audios;
    private bool eggmanMuerto = false;

    public int vidaInicial = 50;
    public int vida = 50;
    public GameObject barraDeVida;
    private float tamañoBarraVidaInicial;

    // Start is called before the first frame update
    void Start()
    {
        tamañoBarraVidaInicial = this.barraDeVida.transform.localScale.x;
        StartCoroutine(escogerMovimiento());
        audios = GetComponents<AudioSource>();
        StartCoroutine(EggmanSays());
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            movimientoArriba();
        }
        
        if (collision.gameObject.tag == "Limite")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name == "SonicBola")
        {
            audios[2].Play(); //Yeah
            vida--;
            this.barraDeVida.transform.localScale = new Vector3(vida * tamañoBarraVidaInicial / vidaInicial, 1, 1);
            print(vida);
            if (vida == 0)
            {
                audios[3].Play();
                eggmanMuerto = true;
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(Win());
            }
        }
    }

    private IEnumerator escogerMovimiento()
    {
        while (!eggmanMuerto)
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
                    audios[0].Play(); //Sonic
                    break;
                case 1:
                    audios[1].Play(); //WorldIsMine
                    break;

            }
        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Win");
    }
}
