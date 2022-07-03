using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag.Equals("Player")){
            player.transform.position = new Vector3(0,0,0);
        }
         
    }
}
