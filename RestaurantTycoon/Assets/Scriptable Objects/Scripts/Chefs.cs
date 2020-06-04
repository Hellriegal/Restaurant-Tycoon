using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;

//The script to create a database of chefs
[CreateAssetMenu(fileName = "Chefs", menuName = "Scriptable Objects/Chefs", order = 1)]
public class Chefs : ScriptableObject
{
    [Serializable]
    public struct chef
    {
        public bool atOven;
        public bool isCooking;
        public bool finishedMeal;
        public int chefID;
        public int orderID;
        public Vector3Int position;

        public chef(bool oven, bool cooking, bool meal, int ID, int OID, Vector3Int positionPass)
        {
            atOven = oven;
            isCooking = cooking;
            finishedMeal = meal;
            chefID = ID;
            orderID = OID;
            position = positionPass;
        }
    }

    public List<chef> chefs;

    public void OnEnable()
    {
        chefs = new List<chef>();
    }

    public void addChef(int ID, Vector3Int position)
    {
        chefs.Add(new chef(false, false, false, ID, 0, position));
    }
}
