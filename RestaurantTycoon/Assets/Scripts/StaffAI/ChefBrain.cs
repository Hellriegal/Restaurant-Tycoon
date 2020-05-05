using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChefBrain : MonoBehaviour
{
    TilemapToMovement movement;
    public TileBase[] ovens;
    DijkstraOptimised pathFinder;
    Vector3Int goal;
    public GridLayout gridLayout;
    Transform myTransform;
    public tileLocate locate;
    bool sitting;
    bool ovenFound;
    public Chefs chefBase;
    int ID;
    [SerializeField]
    int cookTimer;
    // Start is called before the first frame update
    void Start()
    {
        cookTimer = 0;
        ovenFound = false;
        sitting = false;
        movement = GetComponent<TilemapToMovement>();
        goal = new Vector3Int();
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        findOven();
        ID = chefBase.chefs.Count;
        Debug.Log(ID);
        chefBase.addChef(ID, goal);
    }

    // Update is called once per frame
    void Update()
    {
        isAtOven();
        checkForOrder();
    }

    void findOven()
    {
        locate.getAllTilePositions();
        for (int i = 0; i < locate.tiles.Count; i++)
        {
            for (int j = 0; j < ovens.Length; j++)
            {
                if (locate.tiles[i].tileType.name == ovens[j].name & locate.tiles[i].occupied == false)
                {
                    goal = locate.tiles[i].position;
                    locate.tiles[i] = new tileLocate.TileInfo(locate.tiles[i].tileType, locate.tiles[i].position, true);
                    i = locate.tiles.Count;
                    ovenFound = true;
                    break;
                }
            }
        }
        move();
    }

    void move()
    {
        movement.Start();
        pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), goal, true, false);
    }

    void isAtOven()
    {
        if (movement.atGoal == true)
        {
            chefBase.chefs[ID] = new Chefs.chef(true, chefBase.chefs[ID].isCooking, ID, chefBase.chefs[ID].position);
        }
    }

    void checkForOrder()
    {
        if (chefBase.chefs[ID].isCooking == true)
        {
            Debug.Log("time to cook");
        }
    }
}
