using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float timelife=10f;
    // Start is called before the first frame updateza
    void Start()
    {
        Destroy(gameObject,timelife);
        transform.Rotate(90,0,0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*speed);   
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Debug.Log("Toco");
        }
    }    
}
