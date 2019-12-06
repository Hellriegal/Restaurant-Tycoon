using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayoutManager : MonoBehaviour
{
    public GameObject canvas;
    Transform myTransform;
    public MenuItem[] items;
    int counter = 0;
    int pageNumber = 0;
    int numberOfPages;

    void Start()
    {   
        myTransform = canvas.GetComponent<Transform>();
        assignItem();
        getNumberOfPages(items.Length);
    }

    void Update()
    {
        nextPage();
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
            if (itemIndex > items.Length-1 || itemIndex == items.Length - 1)
            {
                itemIndex = -1;
            }
            child.gameObject.GetComponent<getItemInfo>().menuItem = items[itemIndex+1];
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
