using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SonicController : MonoBehaviour
{
    public Boolean muerto;
    private int vidas = 5;
    public float speed; //es publico
    public GameObject sonicBola; //Sonic dispara bola
    private bool cooldown = false;
    private int dobleSalto;
    private float contadorSpeed = 0.01f;
    private Vector2 posicionSonic;
    public AudioSource[] audios; //Creamos una array vacía de AudioSources

    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    public GameObject vida5;

    public GameObject ring;
    public GameObject reloj;

    private bool haIdoaIzquierda = false;
    private bool haIdoaDerecha = false;

    public delegate void Rings(int r);
    public event Rings ringsConseguidos; //Creamos el evento "ringsConseguidos" sobre la función "Rings(int r)"
    public UIManager UIManager;

    public delegate void Score(int puntos);
    public event Score scoreConseguido;
    public UIManagerScore UIManagerScore;

    public Sprite SonicBola; //Sonic se convierte en bola para atacar
    public Sprite SonicTabla; //Sonic vuelve a la tabla

    // Start is called before the first frame update
    void Start()
    {
        posicionSonic = this.transform.position;
        audios = GetComponents<AudioSource>(); //La array de AudioSources se llena de todos los componentes de AudioSource del GameObject
        StartCoroutine(SonicSays());
    }

    // Update is called once per frame
    void Update()
    {

        if(UIManagerScore.puntos >= 20000 && UIManager.rings >= 50){
            SceneManager.LoadScene("Boss");
        }
        else
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

                if (posicionSonic.x < this.transform.position.x)
                {
                    scoreConseguido?.Invoke(1);
                    posicionSonic = this.transform.position;
                }
            }
            /*print("Posicion Inicial " + posicionSonic.x);
            print("This transform " + this.transform.position.x);*/

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
                if (!cooldown)
                {
                    this.GetComponent<SpriteRenderer>().sprite = SonicBola;
                    reloj.gameObject.SetActive(false); //para visualizar el cooldown
                    cooldown = true;
                    StartCoroutine(CambioASonicTabla());
                }

            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = SonicTabla;
            }
        }
    }

    IEnumerator CambioASonicTabla()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<SpriteRenderer>().sprite = SonicTabla;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
        reloj.gameObject.SetActive(true); //para visualizar el cooldown
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*int(collision.GetComponent<SpriteRenderer>().sprite.name);*/
        if (this.GetComponent<SpriteRenderer>().sprite == SonicTabla && collision.tag == "Enemigo" && collision.GetComponent<SpriteRenderer>().sprite.name == "SilverSonicLado")
        {
            comprobarMuerto();

        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicTabla && collision.GetComponent<SpriteRenderer>().sprite.name == "SSPinchos")
        {
            comprobarMuerto();

        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicBola && collision.tag == "Enemigo" && collision.GetComponent<SpriteRenderer>().sprite.name == "SilverSonicLado")
        {
            audios[2].Play(); //SSHurted
            Destroy(collision.gameObject);
            scoreConseguido?.Invoke(500);

        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicBola && collision.tag == "Enemigo" && collision.GetComponent<SpriteRenderer>().sprite.name == "SSPinchos")
        {
            comprobarMuerto();
        }

        if(collision.tag == "Ring")
        {
            //Esto es una comprobación de nulidad. Es lo mismo poner el interrogante que decir "if(ringsConseguidos!=null)"
            //Es como decir: hazmelo solo si "ringsConseguidos" no es null
            ringsConseguidos?.Invoke(1);
            audios[0].Play(); //Ring
            Destroy(collision.gameObject); 
        }
        if (collision.tag == "Limite")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }


        if (collision.name.Contains("superdiamanteAzul"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(50);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("superdiamanteVerde"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(100);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("superdiamanteRojo"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(150);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("diamanteAzul"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(5);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("diamanteVerde"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(10);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("diamanteRojo"))
        {
            audios[6].Play(); //Diamond
            scoreConseguido?.Invoke(15);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.GetComponent<SpriteRenderer>().sprite == SonicTabla && collision.gameObject.tag == "Proyectil")
        {
            comprobarMuerto();
            Destroy(collision.gameObject);
        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicBola && collision.gameObject.tag == "Proyectil")
        {
            Destroy(collision.gameObject);
            scoreConseguido?.Invoke(30);
        }
        if (collision.gameObject.tag == "Ground")
        {
            dobleSalto = 0;
        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicBola && collision.gameObject.name == "drEggman")
        {
            scoreConseguido?.Invoke(3000);

        }
        if (this.GetComponent<SpriteRenderer>().sprite == SonicTabla && collision.gameObject.name == "drEggman")
        {
            if (this.vidas > 0)
            {
                audios[5].Play(); //No Way
                ringsConseguidos?.Invoke(-5);
            }
           


        }
    }

    private void comprobarMuerto()
    {
        if (this.vidas > 0)
        {
            audios[1].Play(); //Sonic Hurted
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
            }
            else if (this.vidas == 1)
            {
                this.vida2.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                StartCoroutine(EliminarVida(vida2));
            }
            else if (this.vidas == 0)
            {
                this.vida1.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                this.muerto = true;
                audios[8].Play(); //Oh man
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                StartCoroutine(EliminarVida(vida1));
            }

            if (this.vidas > 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(comeNormalState());
            }
        }
    }

    private IEnumerator EliminarVida(GameObject vidaAEliminar)
    {
        yield return new WaitForSeconds(2);
        Destroy(vidaAEliminar.gameObject);
        if (this.vidas == 0)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(gameOverScene());
        }
    }

    private IEnumerator gameOverScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
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
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:
                    audios[3].Play(); //VillainDr
                    break;
                case 1:
                    audios[4].Play(); //EggmanCreeps
                    break;
                case 2:
                    audios[7].Play(); //NobodysFaster
                    break;

            }
        }
    }
}

