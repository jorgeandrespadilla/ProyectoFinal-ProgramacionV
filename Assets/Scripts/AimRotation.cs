using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AimRotation : MonoBehaviour {
    [SerializeField]
    private Transform Objetivo;
    void Update() {
        Vector3 OrientacionDeObjetivo = Objetivo.position-transform.position;
        Debug.DrawRay(transform.position,OrientacionDeObjetivo,Color.green);
        Quaternion OrientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation,OrientacionDeObjetivoQuaternion,Time.deltaTime);
    }
}
