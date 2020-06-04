using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Manages chefNPC related processes, such as oven location, cooking times, etc.
public class ChefBrain : MonoBehaviour
{
    TilemapToMovement movement;
    public TileBase[] ovens;
    DijkstraOptimised pathFinder;
    Vector3Int goal;
    public GridLayout gridLayout;
    Transform myTransform;
    public tileLocate locate;
    public Chefs chefBase;
    int ID;
    int orderID;
    [SerializeField]
    int cookTimer;
    // Start is called before the first frame update
    void Start()
    {
        cookTimer = 0;
        movement = GetComponent<TilemapToMovement>();
        goal = new Vector3Int();
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        findOven();
        ID = chefBase.chefs.Count;
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
            chefBase.chefs[ID] = new Chefs.chef(true, chefBase.chefs[ID].isCooking, chefBase.chefs[ID].finishedMeal, ID, chefBase.chefs[ID].orderID, chefBase.chefs[ID].position);
        }
    }

    void checkForOrder()
    {
        if (cookTimer == 0 & chefBase.chefs[ID].isCooking == true)
        {
            cookTimer = 1000 + Random.Range(0, 500);
        }
        if (cookTimer > 0)
        {
            cookTimer--;
            if (cookTimer == 0)
            {
                cookTimer = -1;
                chefBase.chefs[ID] = new Chefs.chef(chefBase.chefs[ID].atOven, chefBase.chefs[ID].isCooking, true, ID, chefBase.chefs[ID].orderID, chefBase.chefs[ID].position);
            }
        }
    }
}
