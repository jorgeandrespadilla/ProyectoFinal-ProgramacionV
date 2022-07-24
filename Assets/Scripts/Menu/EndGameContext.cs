using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameContext : MonoBehaviour
{
    public void BackMenu(){
        SceneManager.LoadScene("MenuScene");
    }

    public void Salir()
    {
        Application.Quit();   
    }
}
