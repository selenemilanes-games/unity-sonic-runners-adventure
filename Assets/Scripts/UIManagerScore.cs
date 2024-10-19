using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SonicController;

public class UIManagerScore : MonoBehaviour
{

    public int puntos = 0;
    public SonicController sc;

    void Start()
    {
        puntos = 0;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Score:    ";
        sc.scoreConseguido += aumentarScore; //esto es la suscripcion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aumentarScore(int p)
    {
        puntos += p;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Score:    " + puntos;
    }
}
