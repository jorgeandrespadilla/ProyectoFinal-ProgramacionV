using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerContext : MonoBehaviour
{
    public void Next(){
        SceneManager.LoadScene("Context2");
    }

     public void Back(){
        SceneManager.LoadScene("MenuScene");
    }
}
