using UnityEngine;
using System.Reflection;
using System;

//The script to create a database of ingredient quantities
[CreateAssetMenu(fileName = "Inventory Data", menuName = "Scriptable Objects/Inventory Data", order = 1)]
public class InventoryData : ScriptableObject
{
    public int Basil;
    public int Bread;
    public int BreadCrumbs;
    public int Butter;
    public int Cabanossi;
    public int Cheese;
    public int Chicken;
    public int CoffeeBeans;
    public int Corn;
    public int Custard;
    public int Dough;
    public int Garlic;
    public int Ham;
    public int IceCream;
    public int Lemonade;
    public int Peas;
    public int Pepperoni;
    public int Pineapple;
    public int Potato;
    public int Pumpkin;
    public int Steak;
    public int Sugar;
    public int TeaLeaves;
    public float Tomato;
    public int TomatoBase;

    public void updateCount(string itemName)
    {
        Type myClassType = this.GetType();
        FieldInfo myFieldInfo = myClassType.GetField(itemName);
        myFieldInfo.SetValue(this, Convert.ToInt32(myFieldInfo.GetValue(this)) + 1);
    }
}
