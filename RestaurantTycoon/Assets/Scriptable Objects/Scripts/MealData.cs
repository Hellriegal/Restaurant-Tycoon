using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Meal Data", menuName = "Scriptable Objects/Meal Data", order = 1)]
public class MealData : ScriptableObject
{
    public List<MenuItem> items;

    public void addToList(MenuItem itemToAdd)
    {
        if (items.Contains(itemToAdd) == false)
        {
            items.Add(itemToAdd);
        }
        else
        {
            items.Remove(itemToAdd);
        }
    }
}


