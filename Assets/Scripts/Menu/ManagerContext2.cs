using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerContext2 : MonoBehaviour
{
     public void Next(){
        SceneManager.LoadScene("SelectionMenu");
    }

     public void Back(){
        SceneManager.LoadScene("Context");
    }
}
