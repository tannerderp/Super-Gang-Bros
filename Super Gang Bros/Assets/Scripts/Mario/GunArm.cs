using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunArm : MonoBehaviour
{
    [SerializeField] public int bulletStrength = 1;

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
    }
}
