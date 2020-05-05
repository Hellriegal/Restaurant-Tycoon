using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Chefs", menuName = "Scriptable Objects/Chefs", order = 1)]
public class Chefs : ScriptableObject
{
    [Serializable]
    public struct chef
    {
        public bool atOven;
        public bool isCooking;
        public int chefID;
        public Vector3Int position;

        public chef(bool oven, bool cooking, int ID, Vector3Int positionPass)
        {
            atOven = oven;
            isCooking = cooking;
            chefID = ID;
            position = positionPass;
        }
    }

    public List<chef> chefs;

    public void addChef(int ID, Vector3Int position)
    {
        chefs.Add(new chef(false, false, ID, position));
    }
}
