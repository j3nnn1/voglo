using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void OnJugar()
    {
        Debug.Log("Jugar");
        SceneManager.LoadScene("principal");
    }

    public void OnSalir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
