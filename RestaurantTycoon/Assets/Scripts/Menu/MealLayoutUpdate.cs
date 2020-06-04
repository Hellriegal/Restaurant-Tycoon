using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//The specific layout manager for the meal menu
public class MealLayoutUpdate: MonoBehaviour
{
    LayoutManager layoutManager;
    public List<MenuItem> Entrees;
    public List<MenuItem> Mains;
    public List<MenuItem> Desserts;
    public List<MenuItem> Drinks;

    void Start()
    {
        layoutManager = GetComponent<LayoutManager>();
    }

    void Update()
    {
        
    }

    public void updateList(string listName)
    {
        switch(listName)
        {
            case "Desserts":
            {
                layoutManager.Items = new List<MenuItem>(Desserts);
            }
            break;
            case "Mains":
            {
                layoutManager.Items = new List<MenuItem>(Mains);
            }
            break;
            case "Drinks":
            {
                layoutManager.Items = new List<MenuItem>(Drinks);
            }
            break;
            case "Entrees":
            {
                layoutManager.Items = new List<MenuItem>(Entrees);
            }
            break;
        }
        layoutManager.Start();
        layoutManager.pageNumberReset();
    }
}
