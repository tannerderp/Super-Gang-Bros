using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Koopa")
        {
            other.gameObject.GetComponent<Koopa>().OutOfPipe = true;
        }
    }
}
