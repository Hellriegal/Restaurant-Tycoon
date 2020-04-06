using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomerBrain : MonoBehaviour
{
    TilemapToMovement movement;
    public TileBase[] chairs;
    DijkstraOptimised pathFinder;
    Vector3Int goal;
    public GridLayout gridLayout;
    Transform myTransform;
    public tileLocate locate;
    bool sitting;
    bool chairFound;
    public Customers customerBase;
    // Start is called before the first frame update
    void Start()
    {
        chairFound = false;
        sitting = false;
        movement = GetComponent<TilemapToMovement>();
        goal = new Vector3Int();
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        findChair();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfSitting();
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
                    Debug.Log("ChairFound");
                    break;
                }
            }
        }
        move();
    }

    void checkIfSitting()
    {
        if (movement.atGoal == true & chairFound == true)
        {
            Debug.Log("sitting");
            sitting = true;
            customerBase.addCustomer(sitting, goal);
            chairFound = false;
        }
    }

    void move()
    {
        movement.Start();
        pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), goal, true);
    }
}
