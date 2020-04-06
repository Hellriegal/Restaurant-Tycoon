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
        bool isSitting;
        Vector3Int position;

        public customer(bool sitting, Vector3Int positionPass)
        {
            isSitting = sitting;
            position = positionPass;
        }
    }

    public List<customer> customers;

    public void addCustomer(bool sitting, Vector3Int position)
    {
        customers.Add(new customer(sitting, position));
    }
}
