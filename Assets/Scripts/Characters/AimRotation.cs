using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AimRotation : MonoBehaviour {
    private Transform objetivo;

    void Start(){
        objetivo = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update() {
        Vector3 OrientacionDeObjetivo = objetivo.position-transform.position;
        Debug.DrawRay(transform.position,OrientacionDeObjetivo,Color.green);
        Quaternion OrientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation,OrientacionDeObjetivoQuaternion,Time.deltaTime);
    }
}
