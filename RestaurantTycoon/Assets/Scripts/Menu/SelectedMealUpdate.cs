using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMealUpdate : MonoBehaviour
{
    LayoutManager layoutManager;
    public MealData mData;

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
                layoutManager.Items = new List<MenuItem>(mData.Desserts);
            }
            break;
            case "Mains":
            {
                layoutManager.Items = new List<MenuItem>(mData.Mains);
            }
            break;
            case "Drinks":
            {
                layoutManager.Items = new List<MenuItem>(mData.Drinks);
            }
            break;
            case "Entrees":
            {
                layoutManager.Items = new List<MenuItem>(mData.Entrees);
            }
            break;
        }
        layoutManager.Start();
        layoutManager.pageNumberReset();
    }
}
