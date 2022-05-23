using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{   
    public int rposx;
    public  int rposy;
    public int rposz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meteorRotate(rposx,rposy,rposz);
    }

    public void meteorRotate(int rposx, int rposy,int rposz)
    {
        rposx= (int)Random.Range(0f,150f);
        rposy= (int)Random.Range(0f,150f);
        rposz= (int)Random.Range(0f,150f);
        transform.Rotate(new Vector3(rposx,rposy,rposz)*Time.deltaTime);
    }
}
