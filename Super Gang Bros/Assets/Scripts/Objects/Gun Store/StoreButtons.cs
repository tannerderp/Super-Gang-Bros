using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] private GameObject mario;
    [SerializeField] private GunArm marioGun;

    [SerializeField] private int price;
    [SerializeField] private enum ItemTypes { bullet, heart};
    [SerializeField] private ItemTypes itemType;
    [SerializeField] private int bulletUpgradeAmount = 2; //what the strength of mario's bullet gets set to after purchase
    [SerializeField] private int healthUpgradeAmount = 7;

    //functions for buttons in the store
    public void ExitButton()
    {
        mario.GetComponent<PlayerMovement>().CanMove = true;
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void ItemButton() //used for any item being purchased
    {
        if(mario.GetComponent<PlayerMovement>().money >= price)
        {
            mario.GetComponent<PlayerMovement>().money -= price;
            if(itemType == ItemTypes.bullet)
            {
                marioGun.bulletStrength = bulletUpgradeAmount;
                GetComponent<Button>().interactable = false;
            }
            else if(itemType == ItemTypes.heart)
            {
                healthUpgradeAmount--;
                if(healthUpgradeAmount <= 0)
                {
                    GetComponent<Button>().interactable = false;
                }
                mario.GetComponent<PlayerMovement>().health++;
                GetComponentInChildren<Text>().text = "Health Upgrade - $10 \n" + healthUpgradeAmount + " remain";
            }
        }
    }
}
