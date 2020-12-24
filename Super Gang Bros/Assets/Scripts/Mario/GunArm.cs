using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.localRotation = Quaternion.identity;
        hand.transform.localRotation = Quaternion.identity;
        transform.localEulerAngles = new Vector3(10.668f, target.transform.localEulerAngles.x-90, -66.806f);
        hand.transform.localEulerAngles = new Vector3(-6.362f, hand.transform.localEulerAngles.y, -34.413f);
        //hand.transform.localRotation = Quaternion.identity;
        /*Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation *= lookRotation;*/
        //Quaternion.FromToRotation(transform.position, target.transform.position);
        //transform.LookAt(target.transform);
        //transform.localEulerAngles = new Vector3(10.668f, -87.358f, -66.806f);
        //transform.localEulerAngles = new Vector3(transform.rotation.x+90, -87.358f, transform.rotation.z);
        //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.z, -38.181f, 0);
        //transform.localEulerAngles = new Vector3(10.668f, -87.358f, -66.806f);
        /*transform.LookAt(target.transform);
        transform.localEulerAngles = new Vector3(10.668f, transform.localRotation.y*100-90, -66.806f);*/
        //hand.transform.localEulerAngles = new Vector3(-6.362f, 5.805f, -34.413f);
        //hand.transform.LookAt(target.transform);
    }
}
