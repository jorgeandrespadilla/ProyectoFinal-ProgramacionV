using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void Empezar(){
        SceneManager.LoadScene("Context");
    }

    public void Credits(){
        SceneManager.LoadScene("CreditScene");

    }
    public void Menus(){
        SceneManager.LoadScene("Context2");

    }


    public void Salir()
    {

        Application.Quit();   
    }
}
