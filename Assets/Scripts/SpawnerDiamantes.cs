using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDiamantes : MonoBehaviour
{
    public GameObject[] diamantes;

    void Start()
    {
        StartCoroutine(CrearDiamantes());
    }

    
    void Update()
    {

    }

    IEnumerator CrearDiamantes()
    {
        while (true)
        {

            switch (Random.Range(0,3))
            {
                case 0:
                    int numRandom = Random.Range(0, diamantes.Length);
                    float randomY = Random.Range(-2.56f, 2);

                    GameObject nuevoDiamante1 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante1.transform.position = this.transform.position;
                    nuevoDiamante1.transform.position = new Vector3(nuevoDiamante1.transform.position.x, randomY, +10);

                    GameObject nuevoDiamante2 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante2.transform.position = this.transform.position;
                    nuevoDiamante2.transform.position = new Vector3(nuevoDiamante2.transform.position.x + 1, randomY, +10);

                    GameObject nuevoDiamante3 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante3.transform.position = this.transform.position;
                    nuevoDiamante3.transform.position = new Vector3(nuevoDiamante3.transform.position.x + 2, randomY, +10);

                    GameObject nuevoDiamante4 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante4.transform.position = this.transform.position;
                    nuevoDiamante4.transform.position = new Vector3(nuevoDiamante4.transform.position.x + 3, randomY, +10);

                    GameObject nuevoDiamante5 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante5.transform.position = this.transform.position;
                    nuevoDiamante5.transform.position = new Vector3(nuevoDiamante5.transform.position.x + 4, randomY, +10);
                    break;
                case 1:
                    numRandom = Random.Range(0, diamantes.Length);

                    GameObject nuevoDiamante6 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante6.transform.position = this.transform.position;
                    nuevoDiamante6.transform.position = new Vector3(nuevoDiamante6.transform.position.x, nuevoDiamante6.transform.position.y, +10);

                    GameObject nuevoDiamante7 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante7.transform.position = this.transform.position;
                    nuevoDiamante7.transform.position = new Vector3(nuevoDiamante7.transform.position.x + 0.5f, nuevoDiamante7.transform.position.y - 0.5f, +10);

                    GameObject nuevoDiamante8 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante8.transform.position = this.transform.position;
                    nuevoDiamante8.transform.position = new Vector3(nuevoDiamante8.transform.position.x, nuevoDiamante8.transform.position.y - 1, +10);

                    GameObject nuevoDiamante9 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante9.transform.position = this.transform.position;
                    nuevoDiamante9.transform.position = new Vector3(nuevoDiamante9.transform.position.x - 0.5f, nuevoDiamante9.transform.position.y - 0.5f, +10);
                    break;

                case 2:
                    numRandom = Random.Range(0, diamantes.Length);
                    randomY = Random.Range(-2.56f, 2);

                    GameObject nuevoDiamante18 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante18.transform.position = this.transform.position;
                    nuevoDiamante18.transform.position = new Vector3(nuevoDiamante18.transform.position.x, nuevoDiamante18.transform.position.y, +10);

                    GameObject nuevoDiamante19 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante19.transform.position = this.transform.position;
                    nuevoDiamante19.transform.position = new Vector3(nuevoDiamante19.transform.position.x + 1, nuevoDiamante18.transform.position.y + 1, +10);

                    GameObject nuevoDiamante20 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante20.transform.position = this.transform.position;
                    nuevoDiamante20.transform.position = new Vector3(nuevoDiamante20.transform.position.x + 2, nuevoDiamante18.transform.position.y + 2, +10);

                    GameObject nuevoDiamante21 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante21.transform.position = this.transform.position;
                    nuevoDiamante21.transform.position = new Vector3(nuevoDiamante21.transform.position.x + 3, nuevoDiamante18.transform.position.y + 3, +10);

                    GameObject nuevoDiamante22 = Instantiate(diamantes[numRandom]);
                    nuevoDiamante22.transform.position = this.transform.position;
                    nuevoDiamante22.transform.position = new Vector3(nuevoDiamante22.transform.position.x + 4, nuevoDiamante18.transform.position.y + 4, +10);
                    break;
            }
           

            int tiempoEspera = Random.Range(1, 3);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
