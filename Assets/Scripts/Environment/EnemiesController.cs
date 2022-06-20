using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float life = 120f;
    private Transform target;
    [SerializeField]
    private GameObject Bullet;
    public int count;
    private bool canShoot = true;
    private float fireRate = 0.5f;
    private float nextShot = -1f;
    private int maxBullet=5;


    void Start(){
        target = GameObject.Find("Player").GetComponent<Transform>();
        count = 0;
    }

    void Update(){
        TargetEnemy();
        Debug.Log("Vida de enemigo: "+ life);
        if(Time.time > nextShot && count < maxBullet){
            canShoot = true;
        }else{
            canShoot = false;
        }
        if(canShoot == true){
            FireBulletCR();
            nextShot = Time.time + fireRate;   
        } 
    }

    private void TargetEnemy(){

        Vector3 OrientacionDeObjetivo = target.position-transform.position;
        Debug.DrawRay(transform.position,OrientacionDeObjetivo,Color.green);
        Quaternion OrientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation,OrientacionDeObjetivoQuaternion,Time.deltaTime);
    }

    private void FireBulletCR()
    {
        Instantiate(Bullet,transform.position,transform.rotation);
        count++;
    }
}