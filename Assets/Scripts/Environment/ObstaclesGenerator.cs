using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public GameObject meteors1;
    public GameObject meteors2;

    public GameObject meteors3;
    
    public float rangeRandom=100f;
    public int quantityOfMeteors =200;


    // Start is called before the first frame update
    void Start()
    {
       skyboxGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createMeteor1()
    {
        float posX = Random.Range(-rangeRandom,rangeRandom);
        float posy = Random.Range(-rangeRandom,rangeRandom);
        float posz = Random.Range(-rangeRandom,rangeRandom);
         Vector3 meteorPosition= new Vector3(posX,posy, posz);
       Instantiate(meteors1,meteorPosition,meteors1.transform.rotation);
       
    }
     public void createMeteor2()
    {
        float posX = Random.Range(-rangeRandom,rangeRandom);
        float posy = Random.Range(-rangeRandom,rangeRandom);
        float posz = Random.Range(-rangeRandom,rangeRandom);
         Vector3 meteorPosition= new Vector3(posX,posy, posz); 
       Instantiate(meteors2,meteorPosition,meteors2.transform.rotation);
      
    }
     public void createMeteor3()
    {
        float posX = Random.Range(-rangeRandom,rangeRandom);
        float posy = Random.Range(-rangeRandom,rangeRandom);
        float posz = Random.Range(-rangeRandom,rangeRandom);
         Vector3 meteorPosition= new Vector3(posX,posy, posz);
       Instantiate(meteors3,meteorPosition,meteors3.transform.rotation);
    }

    public void skyboxGenerator()
    {
       
        for (int i=0 ; i <= quantityOfMeteors ; i++)
        {
            createMeteor1();
            createMeteor2();
            createMeteor3();
        }
    }
}
