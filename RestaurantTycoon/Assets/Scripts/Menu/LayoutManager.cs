using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayoutManager : MonoBehaviour
{
    public GameObject canvas;
    Transform myTransform;
    public MenuItem[] IngredientItems;
    int counter = 0;
    int pageNumber = 0;
    int numberOfPages;
    public PlayerStats stats;
    public GameObject IngredientMenu;

    void Start()
    {   
        myTransform = canvas.GetComponent<Transform>();
        assignItem();
        getNumberOfPages(IngredientItems.Length);
    }

    void Update()
    {
        noMoney();
        nextPage();
        pageNumberReset();
    }

    public void pageNumberReset()
    {
        if (IngredientMenu.activeInHierarchy == false)
        {
            pageNumber = 0;
            counter = 0;
            assignItem();
        }
    }

    void noMoney()
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

    void getNumberOfPages(int totalItems)
    {
        numberOfPages = Mathf.CeilToInt(totalItems/18);
    }

    void assignItem()
    {
        foreach (Transform child in myTransform)
        {
            int itemIndex = counter+(pageNumber*18);
            if (itemIndex > IngredientItems.Length-1 || itemIndex == IngredientItems.Length - 1)
            {
                itemIndex = -1;
            }
            child.gameObject.GetComponent<getItemInfo>().menuItem = IngredientItems[itemIndex+1];
            counter++;
            getItemInfo itemInfo = child.gameObject.GetComponent<getItemInfo>();
            PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();
            itemInfo.Start();
            purchasePass.getItemName();
        }
    }

    void nextPage()
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
