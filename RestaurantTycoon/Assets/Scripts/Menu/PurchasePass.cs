using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void getItemName()
    {
        itemNameText = itemInfo.itemName;
    }

    public void pass()
    {
        purchase.checkPrice(itemNameText);
    }
}
