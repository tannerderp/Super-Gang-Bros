using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEnterPoint : MonoBehaviour
{
    private BoxCollider collider;
    [SerializeField] private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "mario")
        {
            other.gameObject.GetComponent<PlayerMovement>().CanMove = false;
            canvas.SetActive(true);
        }
    }
}
