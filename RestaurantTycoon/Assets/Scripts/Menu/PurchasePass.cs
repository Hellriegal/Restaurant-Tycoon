using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasePass : MonoBehaviour
{
    Button thisButton;
    getItemInfo itemInfo;
    string itemNameText;
    public Purchase purchase;

    void Start()
    {
        thisButton = GetComponent<Button>();
        itemInfo = GetComponent<getItemInfo>();
        getItemName();
        thisButton.onClick.AddListener(pass);
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
        purchase.checkPrice(itemNameText);
    }
}
