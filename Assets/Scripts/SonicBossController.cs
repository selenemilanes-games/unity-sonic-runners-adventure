using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicBossController : MonoBehaviour
{
    public Boolean muerto = false;
    private int vidas = 5;
    public float speed; //es publico
    public GameObject sonicBola; //Sonic dispara bola
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    public GameObject vida5;

    private int dobleSalto;
    private float contadorSpeed = 0.01f;
    public AudioSource[] audios; //Creamos una array vacía de AudioSources

    private bool haIdoaIzquierda = false;
    private bool haIdoaDerecha = false;

    public Sprite SonicBola; //Sonic se convierte en bola para atacar
    public Sprite SonicTabla; //Sonic vuelve a la tabla

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>(); //La array de AudioSources se llena de todos los componentes de AudioSource del GameObject
        StartCoroutine(SonicSays());
    }

    // Update is called once per frame
    void Update()
    {
            if (contadorSpeed < 6)
            {
                contadorSpeed += 0.01f;
            }

            if (Input.GetKeyDown(KeyCode.P) && !this.muerto)
            {
                if (Time.timeScale == 1)
                {    //si la velocidad es 1
                    Time.timeScale = 0;     //que la velocidad del juego sea 0
                }
                else if (Time.timeScale == 0)
                {   // si la velocidad es 0
                    Time.timeScale = 1;     // que la velocidad del juego regrese a 1

                    //"Time.timeScale" es una propiedad de Unity que controla la velocidad a la que pasa el tiempo en el juego.
                    //Cuando timeScale es 1.0, el tiempo pasa tan rápido como en la vida real. Cuando timeScale es 0.5,
                    //el tiempo pasa el doble de despacio que en la vida real. Cuando timeScale se establece a cero,
                    //el juego se pausa si todas tus funciones son independientes del frame rate
                }
            }

            if (Input.GetKey(KeyCode.A) && Time.timeScale == 1 && !this.muerto)
            {
                if (haIdoaDerecha == true)
                {
                    contadorSpeed = contadorSpeed / 2;
                    haIdoaDerecha = false;
                }
                haIdoaIzquierda = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed - contadorSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
                this.GetComponent<SpriteRenderer>().flipX = true;

            }
            else if (Input.GetKey(KeyCode.D) && Time.timeScale == 1 && !this.muerto)
            {
                if (haIdoaIzquierda == true)
                {
                    contadorSpeed = contadorSpeed / 2;
                    haIdoaIzquierda = false;
                }
                haIdoaDerecha = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed + contadorSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
                this.GetComponent<SpriteRenderer>().flipX = false;

            }
           
            if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && !this.muerto)
            {
                if (dobleSalto < 2)
                {
                    this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 320));
                    dobleSalto++;
                }
            }

            if (Input.GetKey(KeyCode.M) && Time.timeScale == 1 && !this.muerto)
            {
                    this.GetComponent<SpriteRenderer>().sprite = SonicBola;

            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = SonicTabla;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Limite")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "Proyectil")
        {
            comprobarMuerto();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.gameObject.tag == "Ground")
        {
            dobleSalto = 0;
        }
    }

    private void comprobarMuerto()
    {
        if (this.vidas > 0)
        {
            audios[1].Play();
            this.vidas--;

            if (this.vidas == 4)
            {
                this.vida5.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(EliminarVida(vida5));
            }
            else if (this.vidas == 3)
            {
                this.vida4.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(EliminarVida(vida4));
            }
            else if (this.vidas == 2)
            {
                this.vida3.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(EliminarVida(vida3));
            }else if (this.vidas == 1)
            {
                this.vida2.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(EliminarVida(vida2));
            }else if (this.vidas == 0)
            {
                this.vida1.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                this.muerto = true;
                audios[0].Play(); //Oh man
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                StartCoroutine(EliminarVida(vida1));
            }

            if(this.vidas > 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(comeNormalState());
            }
            
        }
    }

    IEnumerator comeNormalState()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator SonicSays()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(6, 11));
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    audios[2].Play(); //VillainDr
                    break;
                case 1:
                    audios[3].Play(); //This isn't funny
                    break;

            }
        }
    }

    private IEnumerator EliminarVida(GameObject vidaAEliminar)
    {
        yield return new WaitForSeconds(2);
        Destroy(vidaAEliminar.gameObject);
        if (this.vidas == 0)
        { 
            StartCoroutine(gameOverScene());
        }
    }

    private IEnumerator gameOverScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}

