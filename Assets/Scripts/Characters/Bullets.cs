using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

   [SerializeField]
    private float timer =2f;
     [SerializeField]
    private int maxBullet=5;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBulletCR());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireBulletCR()
    {
        Debug.Log("Inicio de disparador");
        for( int i=0; i<maxBullet;i++)
        {
            counter++;
            Instantiate(Bullet,transform.position,transform.rotation);
            yield return new WaitForSeconds(timer);
        }
        Debug.Log("Fin disparos");
    }
}
