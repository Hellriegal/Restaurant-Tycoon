using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Passes information from the holding object to the getItemInfo script
public class PurchasePass : MonoBehaviour
{
    getItemInfo itemInfo;
    string itemNameText;
    public Purchase purchase;

    void Start()
    {
        itemInfo = GetComponent<getItemInfo>();
        getItemName();
    }

    public void noMoney(bool ifTrue)
    {
        if (itemInfo)
            itemInfo.noMoney(ifTrue);
    }

    public void getItemName()
    {
        if (itemInfo)
            itemNameText = itemInfo.itemName;
    }

    public void pass()
    {
        purchase.checkPrice(itemInfo.priceValue, itemInfo.itemName);
    }
}
