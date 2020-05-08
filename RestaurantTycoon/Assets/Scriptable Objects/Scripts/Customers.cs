using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Customers", menuName = "Scriptable Objects/Customers", order = 1)]
public class Customers : ScriptableObject
{
    [Serializable]
    public struct customer
    {
        public bool isSitting;
        public bool hasBeenServed;
        public bool hasFinishedEating;
        public bool hasOrdered;
        public int customerID;
        public Vector3Int position;

        public customer(bool sitting, bool served, bool finishedEating, bool ordered, int ID, Vector3Int positionPass)
        {
            isSitting = sitting;
            hasBeenServed = served;
            hasFinishedEating = finishedEating;
            hasOrdered = ordered;
            customerID = ID;
            position = positionPass;
        }
    }

    public List<customer> customers;

    public void addCustomer(bool sitting, int ID, Vector3Int position)
    {
        customers.Add(new customer(sitting, false, false, false, ID, position));
    }

    public int getListIndex(int id)
    {
        if (customers.Count > 0)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].customerID == id)
                {
                    return i;
                }
            }
            return 0;
        }
        else
        {
            return 0;
        }
        
    }
}
