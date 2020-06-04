using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;

//The script to create a database of selected meals
[CreateAssetMenu(fileName = "Meal Data", menuName = "Scriptable Objects/Meal Data", order = 1)]
public class MealData : ScriptableObject
{
    public List<MenuItem> Entrees, Mains, Desserts, Drinks;

    public void addToList(MenuItem itemToAdd, string ListName)
    {
        switch(ListName)
        {
            case "Entrees":
            {
                if (Entrees.Contains(itemToAdd) == false)
                {
                    Entrees.Add(itemToAdd);
                }
                else
                {
                    Entrees.Remove(itemToAdd);
                }
            }
            break;
            case "Mains":
            {
                if (Mains.Contains(itemToAdd) == false)
                {
                    Mains.Add(itemToAdd);
                }
                else
                {
                    Mains.Remove(itemToAdd);
                }
            }
            break;
            case "Desserts":
            {
                if (Desserts.Contains(itemToAdd) == false)
                {
                    Desserts.Add(itemToAdd);
                }
                else
                {
                    Desserts.Remove(itemToAdd);
                }
            }
            break;
            case "Drinks":
            {
                if (Drinks.Contains(itemToAdd) == false)
                {
                    Drinks.Add(itemToAdd);
                }
                else
                {
                    Drinks.Remove(itemToAdd);
                }
            }
            break;
            
        }
        
    }
}


