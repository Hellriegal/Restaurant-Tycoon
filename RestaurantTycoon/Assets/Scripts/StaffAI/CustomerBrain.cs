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
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<TilemapToMovement>();
        goal = new Vector3Int();
        myTransform = GetComponent<Transform>();
        pathFinder = GetComponent<DijkstraOptimised>();
        //findChair();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            findChair();
            move();
        }
    }

    void findChair()
    {
        locate.getAllTilePositions();
        for (int i = 0; i < locate.tiles.Count; i++)
        {
            for (int j = 0; j < chairs.Length; j++)
            {
                if (locate.tiles[i].tileType.name == chairs[j].name)
                {
                    goal = locate.tiles[i].position;
                    i = locate.tiles.Count;
                    break;
                }
            }
        }
    }

    void move()
    {
        movement.Start();
        pathFinder.startProcess(gridLayout.WorldToCell(myTransform.position), goal, true);
    }
}
