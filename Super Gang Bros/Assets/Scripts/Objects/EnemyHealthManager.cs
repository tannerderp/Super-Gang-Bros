using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private string type;

    private Koopa koopa; //im gonna have a bunch of things because inefficiency and not knowing how to do things and shiz

    private void Start()
    {
        koopa = GetComponent<Koopa>();
    }

    public void LoseHealth(int amount) //i hate everything about typescripts and c#
    {
        if(type == "koopa")
        {
            koopa.health -= amount;
        }
    }
}
