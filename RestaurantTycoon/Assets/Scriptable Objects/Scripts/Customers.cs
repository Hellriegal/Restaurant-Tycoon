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
        public Vector3Int position;

        public customer(bool sitting, bool served, bool finishedEating, Vector3Int positionPass)
        {
            isSitting = sitting;
            hasBeenServed = served;
            hasFinishedEating = finishedEating;
            position = positionPass;
        }
    }

    public List<customer> customers;

    public void addCustomer(bool sitting, Vector3Int position)
    {
        customers.Add(new customer(sitting, false, false, position));
    }
}
