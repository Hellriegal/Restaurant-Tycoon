﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class TilemapToMovement : MonoBehaviour
{
    Transform myTransform;
    public GridLayout gridLayout;
    public List<Vector3Int> path;
    DijkstraOptimised pathfinder;
    int counter;
    bool checkMovement;
    bool updateCounter;
    public float speed = 1;
    public bool atGoal;
    // Start is called before the first frame update
    public void Start()
    {
        atGoal = false;
        path = new List<Vector3Int>();
        pathfinder = GetComponent<DijkstraOptimised>();
        counter = 0;
        updateCounter = true;
        checkMovement = false;
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfinder.backtrackDone == true)
        {
            path = pathfinder.pathBack;
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
        DebugGoals();
    }

    void DebugGoals()
    {
        if (Input.GetKeyDown("9"))
        {
            Start();
            pathfinder.startProcess(gridLayout.WorldToCell(myTransform.position), new Vector3Int (6,14,0), false, false);
        }
        else if (Input.GetKeyDown("0"))
        {
            Start();
            pathfinder.startProcess(gridLayout.WorldToCell(myTransform.position), new Vector3Int (16,-1,0), false, false);
        }
    }

    void movement()
    {
        if (counter == 0)
        {
            checkMovement = false;
            atGoal = true;
            counter = -1;
        }
        else if (counter > 0)
        {
           myTransform.position = Vector3.MoveTowards(myTransform.position, tileToWorld(path[counter-1]), speed);
            if (myTransform.position == tileToWorld(path[counter-1]))
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
