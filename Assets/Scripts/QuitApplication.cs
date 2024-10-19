using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit(); // Sale de la build
        UnityEditor.EditorApplication.isPlaying = false; // Sale del editor de Unity
    }
}
