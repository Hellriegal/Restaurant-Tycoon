using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{
    Transform myTransform;
    public List<MenuItem> Items;
    public List<DecorationItem> decorationItems;
    int counter = 0;
    int pageNumber = 0;
    int numberOfPages;
    public PlayerStats stats;
    public GameObject Menu;
    [SerializeField]
    bool meal = false;
    int buttonCounter = 0;

    public void Start()
    {
        myTransform = GetComponent<Transform>();
        assignItem();
        if (Items.Count > 0)
        {
            getNumberOfPages(Items.Count);
        }
        else if (decorationItems.Count > 0)
        {
            getNumberOfPages(decorationItems.Count);
        }
    }

    void Update()
    {
        noMoney();
        nextPage();
        activeObject();
    }

    public void activeObject()
    {
        if (Menu.activeInHierarchy == false)
        {
            pageNumberReset();
        }

    }

    public void pageNumberReset()
    {
        pageNumber = 0;
        counter = 0;
        assignItem();
    }

    public void noMoney()
    {
        if (meal == false)
        {
            if (stats.Money <= 0)
            {
                foreach (Transform child in myTransform)
                {
                    child.gameObject.GetComponent<PurchasePass>().noMoney(true);
                }
            }
            else if (stats.Money > 0)
            {
                foreach (Transform child in myTransform)
                {
                    child.gameObject.GetComponent<PurchasePass>().noMoney(false);
                }
            }
        }
    }

    public void getNumberOfPages(int totalItems)
    {
        foreach (Transform child in myTransform)
        {
            Button button = child.gameObject.GetComponent<Button>();
            if (button)
            {
                buttonCounter++;
            }
        }
        numberOfPages = Mathf.CeilToInt(totalItems/buttonCounter);
    }

    void assignItem()
    {
        foreach (Transform child in myTransform)
        {
            int itemIndex = counter+(pageNumber*buttonCounter);
            getItemInfo info;
            info = child.gameObject.GetComponent<getItemInfo>();
            if (info)
            {
                if (Items.Count > 0)
                {
                    if (itemIndex > Items.Count-1 || itemIndex == Items.Count - 1)
                    {
                        itemIndex = -1;
                    }
                    info.menuItem = Items[itemIndex+1];
                    counter++;
                    getItemInfo itemInfo = child.gameObject.GetComponent<getItemInfo>();
                    itemInfo.Start();
                    if (meal == false)
                    {
                        PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();                        
                        purchasePass.getItemName();
                    }
                }
                else if (decorationItems.Count > 0)
                {
                    if (itemIndex > decorationItems.Count-1 || itemIndex == decorationItems.Count - 1)
                    {
                        itemIndex = -1;
                    }
                    info.decorationItem = decorationItems[itemIndex+1];
                    counter++;
                    getItemInfo itemInfo = child.gameObject.GetComponent<getItemInfo>();
                    itemInfo.Start();
                    if (meal == false)
                    {
                        PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();                        
                        purchasePass.getItemName();
                    }
                }
            }
        }
    }

    public void nextPage()
    {
        if (Input.GetKey("left"))
        {
            counter = 0;
            if (pageNumber > 0)
            {
                pageNumber--;
            }
            assignItem();
        }
        if (Input.GetKey("right"))
        {
            counter = 0;
            if (pageNumber < numberOfPages)
            {
                pageNumber++;
            }
            assignItem();
        }
    }
}
