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
    bool chairFound;
    public Customers customerBase;
    int ID;
    public PlayerStats playerStats;
    int eatTimer;
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
        findChair();
        start = gridLayout.WorldToCell(myTransform.position);
        ID = generateID();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfSitting();
        checkIfServed();
        eat();
    }

    void checkIfServed()
    {
        if (customerBase.customers.Count > 0)
        {
            int index = customerBase.getListIndex(ID);
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
        locate.getAllTilePositions();
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
                    break;
                }
            }
        }
        move();
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
        Debug.Log("Customer ID = " + randomID);
        return randomID;
    }

    void checkIfSitting()
    {
        if (movement.atGoal == true & chairFound == true)
        {
            sitting = true;
            customerBase.addCustomer(sitting, ID, goal);
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
    }
}
