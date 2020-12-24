using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private GameObject destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "mario")
        {
            other.transform.position = new Vector3(destination.transform.position.x-5, destination.transform.position.y+3, destination.transform.position.z);
        }
    }
}
