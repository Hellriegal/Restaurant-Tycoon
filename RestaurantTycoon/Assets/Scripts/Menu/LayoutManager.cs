﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayoutManager : MonoBehaviour
{
    Transform myTransform;
    public List<MenuItem> Items;
    int counter = 0;
    int pageNumber = 0;
    int numberOfPages;
    public PlayerStats stats;
    public GameObject Menu;
    [SerializeField]
    bool meal = false;

    public void Start()
    {
        myTransform = GetComponent<Transform>();
        assignItem();
        getNumberOfPages(Items.Count);
    }

    void Update()
    {
        noMoney();
        nextPage();
        activeObject();
    }

    void activeObject()
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

    void noMoney()
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

    void getNumberOfPages(int totalItems)
    {
        numberOfPages = Mathf.CeilToInt(totalItems/18);
    }

    void assignItem()
    {
        foreach (Transform child in myTransform)
        {
            int itemIndex = counter+(pageNumber*18);
            getItemInfo info;
            info = child.gameObject.GetComponent<getItemInfo>();
            if (info)
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
                    PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();                        purchasePass.getItemName();
                }
            }
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
