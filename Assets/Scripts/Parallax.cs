using UnityEngine;

public class Parallax : MonoBehaviour
{
    //El [SerializeField] es para setear la variable desde el inspector
    [SerializeField] private float multiplicador;
    private Transform camaraTransform;
    private Vector3 posicionPreviaCamara; //posici�n de la c�mara en el frame previo
    private float spriteWidth, startPosition;

    void Start()
    {
        camaraTransform = Camera.main.transform; //asignamos a "cameraTransform" el componente transform de la c�mara principal
        posicionPreviaCamara = camaraTransform.position; //asignamos a "posicioPreviaCamara" la posici�n inicial de la c�mara
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; //Obtenemos el ancho del sprite
        startPosition = transform.position.x; //asignamos a "startPosition" la posici�n en x que tiene inicialmnete
    }

    void Update()
    {
        //Esto nos da cu�nto se movi� la c�mara en la coord. x desde el frame anterior. 
        //Ej. si en el frame actual la c�mara se encuentra en la posici�n 6 y en el frame anterior se encontraba en la posici�n 5
        //deltaX = 1.
        float deltaX = (camaraTransform.position.x - posicionPreviaCamara.x)*multiplicador;
        //Si el multiplicador fuera "0.5f":
        //0.5f representa qu� porcentaje (50%) del movimiento de la c�mara van a tener las capas
        //Valores cercanos a 1 -> las capas se mueven a una velocidad cercana a la c�mara
        //Sensaci�n de movimiento lento. �til para las capas lejanas
        //Valores cercanos a 0 -> las capas se mueven poco respecto a la c�mara.
        //Sensaci�n de movimiento r�pido. �til para objetos cercanos

        float moveAmount = camaraTransform.position.x * (1 - multiplicador); //Cu�nto se ha movido la c�mara respecto a la capa


        //Ahora haremos que cada una de nuestras capas se mueva en esa cantidad, en ese deltaX
        transform.Translate(new Vector3(deltaX, 0, 0));
        posicionPreviaCamara = camaraTransform.position; //Esto lo hacemos para que luego se pueda calcular el nuevo deltaX

        if(moveAmount>startPosition + spriteWidth) //Si la c�mara est� m�s adelante en un tama�o mayor al ancho del sprite, voy a reposicionar la capa
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
