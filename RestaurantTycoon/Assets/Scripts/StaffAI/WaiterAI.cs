using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterAI : MonoBehaviour
{
    DijkstraOptimised pathFinder;
    public Customers CustomerBase;
    Transform myTransform;
    TilemapToMovement movement;
    public GridLayout gridLayout;
    [SerializeField]
    bool takingOrder;
    bool performingTask;
    [SerializeField]
    int takeOrderCounter;
    public Chefs chefBase;

    int chefID;

    public List<string> tasks;
    // Start is called before the first frame update
    void Start()
    {
        performingTask = false;
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        movement = GetComponent<TilemapToMovement>();
        takingOrder = false;
        takeOrderCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkForCustomers();
        if (takingOrder == true)
        {
            takeOrderCount();
        }
        pickTask();
    }

    void pickTask()
    {
        if (performingTask == false & tasks.Count != 0)
        {
            switch(tasks[0])
            {
                case "tellChef":
                findChef();
                break;
                case "walkToChef":
                tellChefOrder();
                break;
            }

        }
    }

    void checkForCustomers()
    {
        if (tasks.Count == 0)
        {
            for (int i = 0; i < CustomerBase.customers.Count; i++)
            {
                if (CustomerBase.customers[i].hasBeenServed == false)
                {
                    tasks.Add("serve");
                    takeOrder(i);
                    break;
                }
            }
        }
    }

    void takeOrder(int customerIndex)
    {
        if (takingOrder == false)
        {
            takeOrderCounter = 500 + Random.Range(200, 500);
            movement.Start();
            pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), CustomerBase.customers[customerIndex].position, true, true);
            takingOrder = true;
        }
    }

    void takeOrderCount()
    {
        takeOrderCounter--;
            if (takeOrderCounter == 0)
            {
                takingOrder = false;
                tasks.Add("tellChef");
                tasks.RemoveAt(0);
            }
    }

    void findChef()
    {
        for (int i = 0; i < chefBase.chefs.Count; i++)
        {
            if (chefBase.chefs[i].atOven == true)
            {
                chefID = chefBase.chefs[i].chefID;
                movement.Start();
                pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), chefBase.chefs[i].position, true, true);
                tasks.Add("walkToChef");
                tasks.RemoveAt(0);
            }
        }
    }

    void tellChefOrder()
    {
        if (movement.atGoal == true)
        {
            chefBase.chefs[chefID] = new Chefs.chef(chefBase.chefs[chefID].atOven, true, chefBase.chefs[chefID].chefID, chefBase.chefs[chefID].position);
        }
    }
}
