using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] PlayerMovement mario;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = ": " + mario.money;
    }
}
