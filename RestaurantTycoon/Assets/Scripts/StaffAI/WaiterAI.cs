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
    int pickupCounter;
    public Chefs chefBase;
    [SerializeField]
    int customerID;
    int chefID;
    bool findingCustomer;

    public List<string> tasks;
    // Start is called before the first frame update
    void Start()
    {
        findingCustomer = false;
        performingTask = false;
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        movement = GetComponent<TilemapToMovement>();
        takingOrder = false;
        takeOrderCounter = 0;
        pickupCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkForTasks();
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
                pickChef();
                break;
                case "walkToChef":
                tellChefOrder();
                break;
                case "pickUpOrder":
                orderPickUp();
                break;
                case "deliverOrder":
                findCustomer();
                deliverOrder();
                break;
            }
        }
    }

    void deliverOrder()
    {
        if (movement.atGoal == true)
        {
            int id = CustomerBase.getListIndex(customerID);
            CustomerBase.customers[id] = new Customers.customer(CustomerBase.customers[id].isSitting, true, CustomerBase.customers[id].hasFinishedEating, CustomerBase.customers[id].hasOrdered, CustomerBase.customers[id].customerID, CustomerBase.customers[id].position);
            tasks.RemoveAt(0);
        Debug.Log("hit");
        }
    }

    void orderPickUp()
    {
        if (movement.atGoal == true)
        {
            if (pickupCounter > 0)
            {
                pickupCounter--;
            }
            else if (pickupCounter == 0)
            {
                customerID = chefBase.chefs[chefID].orderID;
                tasks.Add("deliverOrder");
                tasks.RemoveAt(0);
            }
        }
    }

    void pickChef()
    {
        for (int i = 0; i < chefBase.chefs.Count; i++)
        {
            if (chefBase.chefs[i].isCooking == false & chefBase.chefs[i].atOven == true)
            {
                findChef(chefBase.chefs[i].position);
                break;
            }
        }
    }

    void checkForTasks()
    {
        if (tasks.Count == 0)
        {
            //Check for finished meals
            for (int i = 0; i < chefBase.chefs.Count; i++)
            {
                if (chefBase.chefs[i].finishedMeal == true)
                {
                    tasks.Add("pickUpOrder");   
                    chefID = chefBase.chefs[i].chefID;
                    findChef(chefBase.chefs[i].position);
                    pickupCounter = 100 + Random.Range(0, 200);       
                    break;
                }
            }
            //check for customers ready to order
            for (int i = 0; i < CustomerBase.customers.Count; i++)
            {
                if (CustomerBase.customers[i].hasOrdered == false)
                {
                    customerID = CustomerBase.customers[i].customerID;
                    tasks.Add("takeOrder");
                    findCustomer();
                    takeOrder();
                    break;
                }
            }
        }
    }

    void findCustomer()
    {
        if (findingCustomer == false)
        {
            findingCustomer = true;
            movement.Start();
            pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), CustomerBase.customers[CustomerBase.getListIndex(customerID)].position, true, true);
        }
    }

    void takeOrder()
    {
        if (takingOrder == false)
        {
            takeOrderCounter = 500 + Random.Range(200, 500);
            takingOrder = true;
        }
    }

    void takeOrderCount()
    {
        takeOrderCounter--;
            if (takeOrderCounter == 0)
            {
                int customerIndex = CustomerBase.getListIndex(customerID);
                takingOrder = false;
                CustomerBase.customers[customerIndex] = new Customers.customer(CustomerBase.customers[customerIndex].isSitting, CustomerBase.customers[customerIndex].hasBeenServed, 
                CustomerBase.customers[customerIndex].hasFinishedEating, true, CustomerBase.customers[customerIndex].customerID, CustomerBase.customers[customerIndex].position);
                tasks.Add("tellChef");
                tasks.RemoveAt(0);
            }
    }

    void findChef(Vector3Int position)
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
            chefBase.chefs[chefID] = new Chefs.chef(chefBase.chefs[chefID].atOven, true, chefBase.chefs[chefID].finishedMeal, chefBase.chefs[chefID].chefID, customerID, chefBase.chefs[chefID].position);
            tasks.RemoveAt(0);
        }
    }
}
