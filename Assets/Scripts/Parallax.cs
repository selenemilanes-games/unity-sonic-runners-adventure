using UnityEngine;

public class Parallax : MonoBehaviour
{
    //El [SerializeField] es para setear la variable desde el inspector
    [SerializeField] private float multiplicador;
    private Transform camaraTransform;
    private Vector3 posicionPreviaCamara; //posición de la cámara en el frame previo
    private float spriteWidth, startPosition;

    void Start()
    {
        camaraTransform = Camera.main.transform; //asignamos a "cameraTransform" el componente transform de la cámara principal
        posicionPreviaCamara = camaraTransform.position; //asignamos a "posicioPreviaCamara" la posición inicial de la cámara
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; //Obtenemos el ancho del sprite
        startPosition = transform.position.x; //asignamos a "startPosition" la posición en x que tiene inicialmnete
    }

    void Update()
    {
        //Esto nos da cuánto se movió la cámara en la coord. x desde el frame anterior. 
        //Ej. si en el frame actual la cámara se encuentra en la posición 6 y en el frame anterior se encontraba en la posición 5
        //deltaX = 1.
        float deltaX = (camaraTransform.position.x - posicionPreviaCamara.x)*multiplicador;
        //Si el multiplicador fuera "0.5f":
        //0.5f representa qué porcentaje (50%) del movimiento de la cámara van a tener las capas
        //Valores cercanos a 1 -> las capas se mueven a una velocidad cercana a la cámara
        //Sensación de movimiento lento. Útil para las capas lejanas
        //Valores cercanos a 0 -> las capas se mueven poco respecto a la cámara.
        //Sensación de movimiento rápido. Útil para objetos cercanos

        float moveAmount = camaraTransform.position.x * (1 - multiplicador); //Cuánto se ha movido la cámara respecto a la capa


        //Ahora haremos que cada una de nuestras capas se mueva en esa cantidad, en ese deltaX
        transform.Translate(new Vector3(deltaX, 0, 0));
        posicionPreviaCamara = camaraTransform.position; //Esto lo hacemos para que luego se pueda calcular el nuevo deltaX

        if(moveAmount>startPosition + spriteWidth) //Si la cámara está más adelante en un tamaño mayor al ancho del sprite, voy a reposicionar la capa
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveAmount < startPosition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
       
    }
}
