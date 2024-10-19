using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int rings;
    public SonicController sc;

    // Start is called before the first frame update
    void Start()
    {
        rings = 0;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "" + rings;
        sc.ringsConseguidos += aumentarRings; //esto es la subscripcion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aumentarRings(int r)
    {
        rings+=r;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "" + rings;
    }
}
