using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


//The script handles interactions between the customer Object and the customer database; functions dealing with the specific customer is held here
public class CustomerBrain : MonoBehaviour
{
    TilemapToMovement movement;
    public TileBase[] chairs;
    DijkstraOptimised pathFinder;
    Vector3Int goal;
    Vector3Int start;
    public GridLayout gridLayout;
    Transform myTransform;
    public tileLocate locate;
    bool sitting;
    [SerializeField]
    bool chairFound;
    public Customers customerBase;
    int ID;
    public PlayerStats playerStats;
    int eatTimer;
    int index;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        eatTimer = 0;
        chairFound = false;
        sitting = false;
        movement = GetComponent<TilemapToMovement>();
        goal = new Vector3Int();
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        start = gridLayout.WorldToCell(myTransform.position);
        ID = generateID();
        index = customerBase.getListIndex(ID);
    }

    // Update is called once per frame
    void Update()
    {
        checkIfSitting();
        checkIfServed();
        eat();
        findChair();
        checkForChairAtPosition();
    }

    void checkIfServed()
    {
        if (customerBase.customers.Count > 0)
        {
            if (customerBase.customers[index].hasBeenServed == true & eatTimer == 0)
            {
                eatTimer = 300 + Random.Range(0, 500);
            }
        }
    }

    void eat()
    {
        if (eatTimer > 1)
        {
            eatTimer--;
        }
        if (eatTimer == 1)
        {
            eatTimer = 0;
            playerStats.addMoney(6);
            leave();
        }
    }

    void findChair()
    {
        if (chairFound == false & customerBase.customers[index].isSitting == false)
        {
            for (int i = 0; i < locate.tiles.Count; i++)
            {
                for (int j = 0; j < chairs.Length; j++)
                {
                    if (locate.tiles[i].tileType.name == chairs[j].name & locate.tiles[i].occupied == false)
                    {
                        goal = locate.tiles[i].position;
                        locate.tiles[i] = new tileLocate.TileInfo(locate.tiles[i].tileType, locate.tiles[i].position, true);
                        i = locate.tiles.Count;
                        chairFound = true;
                        move();
                        return;
                    }
                }
            }
        }
    }

    void checkForChairAtPosition()
    {
        for (int j = 0; j < chairs.Length; j++)
                {
                    if (tilemap.GetTile(gridLayout.WorldToCell(myTransform.position)) != null)
                    {
                        if (tilemap.GetTile(gridLayout.WorldToCell(myTransform.position)).name == chairs[j].name)
                        {
                            customerBase.customers[index] = new Customers.customer(true, customerBase.customers[index].hasBeenServed, customerBase.customers[index].hasFinishedEating, customerBase.customers[index].hasOrdered, customerBase.customers[index].customerID, goal);
                        }
                    }
                    else if (tilemap.GetTile(gridLayout.WorldToCell(myTransform.position)) == null)
                    {
                        customerBase.customers[index] = new Customers.customer(false, customerBase.customers[index].hasBeenServed, customerBase.customers[index].hasFinishedEating, customerBase.customers[index].hasOrdered, customerBase.customers[index].customerID, goal);
                    }
                }
    }

    int generateID()
    {
        int randomID = 0;
        bool IDFound = false;
        while (IDFound == false)
        {
            randomID = UnityEngine.Random.Range(1000, 9999);
            if (customerBase.customers.Count == 0)
            {
                IDFound = true;
            }
            for (int i = 0; i < customerBase.customers.Count; i++)
            {
                if (randomID != customerBase.customers[i].customerID)
                {
                    IDFound = true;
                    break;
                }
            }
        }
        customerBase.addCustomer(sitting, ID, goal);
        return randomID;
    }

    void checkIfSitting()
    {
        if (movement.atGoal == true & chairFound == true)
        {
            sitting = true;
            customerBase.customers[index] = new Customers.customer(true, customerBase.customers[index].hasBeenServed, customerBase.customers[index].hasFinishedEating, customerBase.customers[index].hasOrdered, customerBase.customers[index].customerID, goal);
            chairFound = false;
        }
    }

    void move()
    {
        movement.Start();
        pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), goal, true, false);
    }

    void leave()
    {
        Vector3Int goalHold = goal;
        goal = start;
        start = goalHold;
        move();
    }
}
