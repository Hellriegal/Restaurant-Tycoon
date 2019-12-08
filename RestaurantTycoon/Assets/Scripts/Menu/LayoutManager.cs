using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LayoutManager : MonoBehaviour
{
    Transform myTransform;
    public MenuItem[] IngredientItems;
    public MealItem[] MealItems;
    int counter = 0;
    int pageNumber = 0;
    int numberOfPages;
    public PlayerStats stats;
    public GameObject menu6x3;
    string menuType;

    void Start()
    {   
        myTransform = menu6x3.GetComponent<Transform>();
        assignItem(menuType);
    }

    void Update()
    {
        noMoney();
        nextPage();
        pageNumberReset();
    }

    public void clearObjectAssign()
    {
        foreach (Transform child in myTransform)
            {
                child.gameObject.GetComponent<getItemInfo>().menuItem = null;
                child.gameObject.GetComponent<getItemInfo>().mealItem = null;
            }
    }

    public void getMenuType(string menuTypeString)
    {
        menuType = menuTypeString;
    }

    public void pageNumberReset()
    {
        if (menu6x3.activeInHierarchy == false)
        {
            pageNumber = 0;
            counter = 0;
            assignItem(menuType);
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

    public void assignItem(string arrayName)
    {
        switch (arrayName)
        {
            case "IngredientItems":
            getNumberOfPages(IngredientItems.Length);
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
            break;
            case "MealItems":
            getNumberOfPages(MealItems.Length);
            foreach (Transform child in myTransform)
            {
               int itemIndex = counter+(pageNumber*18);
               if (itemIndex > MealItems.Length-1 || itemIndex == MealItems.Length - 1)
                   {
                        itemIndex = -1;
                   }
                child.gameObject.GetComponent<getItemInfo>().mealItem = MealItems[itemIndex+1];
                counter++;
                getItemInfo itemInfo = child.gameObject.GetComponent<getItemInfo>();
                PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();
                itemInfo.Start();
                purchasePass.getItemName();
                
            }
            break;
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
                assignItem(menuType);
            }
        }
        if (Input.GetKey("right"))
        {
            counter = 0;
            if (pageNumber < numberOfPages+1)
            {
                pageNumber++;
                assignItem(menuType);
            }
        }
        if (pageNumber <= 0)
        {
            pageNumber = 1;
        }
    }
}
