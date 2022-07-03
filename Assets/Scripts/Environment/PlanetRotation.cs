using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public int pposx=0;
    public  int pposy;
    public int pposz=0;
    private float speedRotation=0.04f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetRotate( pposx, pposy,pposz);
    }

     public void PlanetRotate(int pposx, int pposy,int pposz)
    {
        pposy= (int)Random.Range(0f,150f);
        transform.Rotate(new Vector3(pposx,pposy,pposz)*speedRotation*Time.fixedDeltaTime);
    }
}
