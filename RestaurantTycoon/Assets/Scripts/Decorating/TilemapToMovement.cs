using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class TilemapToMovement : MonoBehaviour
{
    Transform transform;
    public GridLayout gridLayout;
    public List<Vector3Int> path;
    public Dijkstra pathfinder;
    public int counter;
    bool checkMovement;
    bool updateCounter;
    // Start is called before the first frame update
    void Start()
    {
        updateCounter = true;
        checkMovement = false;
        path = pathfinder.finalPath;
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfinder.backtrackDone == true)
        {
            checkMovement = true;
        }
        if (updateCounter == true & checkMovement == true)
        {
            counter = path.Count();
            updateCounter = false;
        }
        if (checkMovement == true)
        {
            movement();
        }
    }

    void movement()
    {
        if (counter == 0)
        {
            checkMovement = false;
        }
        else
        {
            if (counter > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, tileToWorld(path[counter-1]), 1);
        }
        if (transform.position == tileToWorld(path[counter-1]))
        {
            counter--;
        }
        }
    }

    public Vector3 tileToWorld(Vector3Int pos)
    {
        Vector3 position;
        position = gridLayout.CellToWorld(pos);
        return position;
    }
}
