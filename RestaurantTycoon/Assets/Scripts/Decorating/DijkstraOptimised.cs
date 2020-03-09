using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class DijkstraOptimised : MonoBehaviour
{
    public int SmallestFirst (Node a, Node b)
    {
        return a.TotalCost.CompareTo (b.TotalCost);
    }

    tileLocate locate;
    [Serializable]
    public struct Node
    {
        public float TotalCost;
        public Vector3Int path;
        public Vector3Int position;
        public Node(float cost, Vector3Int pos, Vector3Int prePos)
        {
            TotalCost = cost;
            position = pos;
            path = prePos;
        }
    }
    public Tilemap tilemap;
    public GridLayout gridLayout;

    public List<Vector3Int> obstacles;
    public List<Vector3Int> checkedPositions;
    public List<Node> checkQueue;
    public List<Node> adjacentTiles;

    Node start;
    Node goal;

    bool goalFound;
    
    void Start()
    {
        goalFound = false;
        start.position = new Vector3Int(0,0,0);
        goal.position = new Vector3Int(30,20,0);
        //tileLocate to get all occupied furniture tiles to use as obstacles.
        locate = tilemap.gameObject.GetComponent<tileLocate>();
        locate.Start();
        locate.getAllTilePositions();
        addTilesToPrevious();
        checkQueue.Add(start);
        search();
    }

    void addTilesToPrevious()
    {
        //Every tile in the tileMap is treated as an obstacle
        for (int i = 0; i < locate.tilesPos.Count(); i++)
        {
            obstacles.Add(locate.tilesPos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            sort();
        }
    }

    void sort()
    {
        checkQueue.Sort(SmallestFirst);
    }

    void search()
    {
        for (int i = 0; i < 400; i++)
        {
            sort();  
            if (checkQueue[0].position == goal.position)
            {
                Debug.Log("Goal Found");
                goalFound = true;
                break;
            }
            pastPositionClear();
            Debug.Log(checkQueue[0].position);
            getAdjacentTiles(checkQueue[0]);
        }
    }

    void pastPositionClear()
    {
        for (int i = 0; i < checkedPositions.Count(); i++)
        {
            for (int j = 0; j < checkQueue.Count(); j++)
            {
                if (checkQueue[j].position == checkedPositions[i])
                {
                    checkQueue.RemoveAt(j);
                    break;
                }
            }
        }
    }

    void getAdjacentTiles(Node currentNode)
    {
        checkQueue.RemoveAt(0);
        adjacentTiles.Clear();
        //Get all adjacent tiles in a 4 way.
        Vector3Int left = new Vector3Int(currentNode.position.x -1, currentNode.position.y, currentNode.position.z);
        Vector3Int right = new Vector3Int(currentNode.position.x +1, currentNode.position.y, currentNode.position.z);
        Vector3Int down = new Vector3Int(currentNode.position.x, currentNode.position.y -1, currentNode.position.z);
        Vector3Int up = new Vector3Int(currentNode.position.x, currentNode.position.y +1, currentNode.position.z);

        //add to adjacentTiles if not the node that we just checked. Used to cut down the search of previous positions by eliminating one now.
        if (left != currentNode.path)
        {
            adjacentTiles.Add(new Node(currentNode.TotalCost, left, currentNode.position));
        }
        if (right != currentNode.path)
        {
            adjacentTiles.Add(new Node(currentNode.TotalCost, right, currentNode.position));
        }
        if (down != currentNode.path)
        {
            adjacentTiles.Add(new Node(currentNode.TotalCost, down, currentNode.position));
        }
        if (up != currentNode.path)
        {
            adjacentTiles.Add(new Node(currentNode.TotalCost, up, currentNode.position));
        }
        //Compare against all previous positions, and remove any that double up
        for (int i = 0; i < checkedPositions.Count(); i++)
        {
            for (int j = 0; j < adjacentTiles.Count(); j++)
            {
                if (adjacentTiles[j].position == checkedPositions[i])
                {
                    adjacentTiles.RemoveAt(j);
                    break;
                }
            }
        }
        //Compare against obstacles
        for (int i = adjacentTiles.Count()-1; i > 0; i--)
        {
            for (int j = 0; j < obstacles.Count(); j++)
            {
                if (adjacentTiles[i].position == obstacles[j])
                {
                    adjacentTiles.RemoveAt(i);
                    break;
                }
            }
        }
        
        //calculate cost then add to checkQueue and checkedPositions
        for (int i = 0; i < adjacentTiles.Count(); i++)
        {
            adjacentTiles[i] = new Node (calculateCost(adjacentTiles[i]), adjacentTiles[i].position, adjacentTiles[i].path);
            checkQueue.Add(adjacentTiles[i]);
            //visualise pathfinding
            Debug.DrawLine(gridLayout.CellToWorld(start.position), gridLayout.CellToWorld(goal.position), Color.blue, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y,adjacentTiles[i].position.z)), gridLayout.CellToWorld(adjacentTiles[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(adjacentTiles[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y,adjacentTiles[i].position.z)), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), Color.red, 1);
        
        }
        
        checkedPositions.Add(currentNode.position);
        checkQueue = checkQueue.Distinct().ToList();
        checkedPositions = checkedPositions.Distinct().ToList();
    }

    float calculateCost(Node thisNode)
    {
        float cost = thisNode.TotalCost;
        cost =+ Vector3.Distance(thisNode.position, goal.position);
        //cost =+ Vector3.Distance(thisNode.position, start.position);
        return cost;
    }
}
