using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImage : MonoBehaviour
{
    public Sprite sonicRunners;

    void Start()
    {
        StartCoroutine(CambioImagen());
    }

   
    void Update()
    {
        
    }

    private IEnumerator CambioImagen()
    {
        yield return new WaitForSeconds(5);
        this.GetComponent<SpriteRenderer>().sprite = sonicRunners;
    }
}
