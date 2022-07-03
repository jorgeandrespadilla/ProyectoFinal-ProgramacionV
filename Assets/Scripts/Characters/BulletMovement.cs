using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed;
    private float timelife;
    public GameObject creator;
    PlayerController playerController;
    EnemiesController enemyController;
    
    public void setCreator(GameObject invoker){
        creator = invoker;
    }

    void Start()
    {
        timelife = 1;
        speed = 500;
        Destroy(gameObject,timelife);
        transform.Rotate(90,0,0);
        if(creator == null){
            creator = GameObject.Find("Player");
        }
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.fixedDeltaTime*speed);   
    }

    private void OnTriggerEnter(Collider other) {
        if(creator.tag.Equals("Enemy")){
            if(other.tag.Equals("Player")){
                Destroy(gameObject);
                playerController.life -=10;
            }
        }else if(creator.tag.Equals("Player")){
            if(other.tag.Equals("Enemy")){
                enemyController = other.GetComponent<EnemiesController>();
                Destroy(gameObject);
                enemyController.life -=10;
            }
        }
    }

    private void OnDestroy() {
        if(creator.tag.Equals("Player")){
            playerController.count -= 1;
        }else if(creator.tag.Equals("Enemy")){
            creator.GetComponent<EnemiesController>().count -= 1;
            Debug.Log(creator.GetComponent<EnemiesController>().count);
        }
    }
}
