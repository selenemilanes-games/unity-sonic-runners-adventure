using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverSonicController : MonoBehaviour
{

    public GameObject SSbola;

    public Sprite SS;
    public Sprite SSpinchos;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
        StartCoroutine(atacar());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnBecameInvisible() //Si el objeto sale fuera de la cámara, se elimina
    {
        Destroy(gameObject);
    }

    public IEnumerator atacar()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0,4));
            switch (Random.Range(0, 2))
            {
                case 0:
                    GameObject bola = Instantiate(SSbola);
                    bola.transform.position = this.transform.position;
                    bola.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity * 2;
                    break;
                case 1:
                    StartCoroutine(SSconPinchos());
                    break;
            }
        }
    }

    public IEnumerator SSconPinchos()
    {
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
        this.GetComponent<SpriteRenderer>().sprite = SSpinchos;
        yield return new WaitForSeconds(1);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        this.GetComponent<SpriteRenderer>().sprite = SS;
        yield return new WaitForSeconds(1);
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
        this.GetComponent<SpriteRenderer>().sprite = SSpinchos;
        yield return new WaitForSeconds(1);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        this.GetComponent<SpriteRenderer>().sprite = SS;
    }
}
