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
    public List<Node> checkedNodes;
    public List<Node> checkQueue;
    public List<Node> adjacentTiles;
    public List<Vector3Int> pathBack;

    Vector3Int start;
    Vector3Int goal;

    bool goalFound;
    public bool backtrackDone;
    
    void Start()
    {
        //Initialise everything here so that I can restart the process
        obstacles = new List<Vector3Int>();
        pathBack = new List<Vector3Int>();
        checkedNodes = new List<Node>();
        checkQueue = new List<Node>();
        adjacentTiles = new List<Node>();
        backtrackDone = false;
        goalFound = false;
        //tileLocate to get all occupied furniture tiles to use as obstacles.
        locate = tilemap.gameObject.GetComponent<tileLocate>();
        locate.Start();
        locate.getAllTilePositions();
        addTilesToPrevious();
        checkQueue.Add(new Node(0, start, start));
    }

    public void startProcess(Vector3Int startPosition, Vector3Int goalPosition)
    {
        start = startPosition;
        goal = goalPosition;
        Start();
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
        if (goalFound == true)
        {
            backtrack();
        }
    }

    void sort()
    {
        checkQueue.Sort(SmallestFirst);
    }

    void search()
    {
        for (int i = 0; i < 700; i++)
        {
            sort();  
            if (checkQueue[0].position == goal)
            {
                checkedNodes.Add(checkQueue[0]);
                Debug.Log("Goal Found");
                goalFound = true;
                backtrack();
                break;
            }
            pastPositionClear();
            getAdjacentTiles(checkQueue[0]);
        }
    }

    void pastPositionClear()
    {
        for (int i = 0; i < checkedNodes.Count(); i++)
        {
            for (int j = 0; j < checkQueue.Count(); j++)
            {
                if (checkQueue[j].position == checkedNodes[i].position)
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
        for (int i = 0; i < checkedNodes.Count(); i++)
        {
            for (int j = 0; j < adjacentTiles.Count(); j++)
            {
                if (adjacentTiles[j].position == checkedNodes[i].position)
                {
                    adjacentTiles.RemoveAt(j);
                    break;
                }
            }
        }
        //Compare against obstacles
        for (int i = 0; i < obstacles.Count(); i++)
        {
            for (int j = 0; j < adjacentTiles.Count(); j++)
            {
                if (adjacentTiles[j].position == obstacles[i])
                {
                    adjacentTiles.RemoveAt(j);
                    break;
                }
            }
        }
        
        //calculate cost then add to checkQueue and checkedNodes
        for (int i = 0; i < adjacentTiles.Count(); i++)
        {
            adjacentTiles[i] = new Node (calculateCost(adjacentTiles[i]), adjacentTiles[i].position, adjacentTiles[i].path);
            checkQueue.Add(adjacentTiles[i]);
            //visualise pathfinding
            Debug.DrawLine(gridLayout.CellToWorld(start), gridLayout.CellToWorld(goal), Color.blue, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y,adjacentTiles[i].position.z)), gridLayout.CellToWorld(adjacentTiles[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(adjacentTiles[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y,adjacentTiles[i].position.z)), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x+1,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), gridLayout.CellToWorld(new Vector3Int(adjacentTiles[i].position.x,adjacentTiles[i].position.y+1,adjacentTiles[i].position.z)), Color.red, 1);
        
        }
        checkedNodes.Add(currentNode);
        checkQueue = checkQueue.Distinct().ToList();
        checkedNodes = checkedNodes.Distinct().ToList();
    }

    float calculateCost(Node thisNode)
    {
        float cost = thisNode.TotalCost;
        cost = Vector3.Distance(thisNode.position, goal) + Vector3.Distance(thisNode.position, start);
        return cost;
    }

    void backtrack()
    {
        Node goalNode = checkedNodes[checkedNodes.Count()-1];
        pathBack.Add(goal);
        while (goalNode.position != start)
        {
            for (int i = 0; i < checkedNodes.Count(); i++)
            {
                if (checkedNodes[i].position == goalNode.path)
                {
                    Debug.DrawLine(gridLayout.CellToWorld(goalNode.position), gridLayout.CellToWorld(checkedNodes[i].position), Color.green, 1);
                    goalNode = checkedNodes[i];
                    pathBack.Add(checkedNodes[i].position);
                    break;
                }
            }
        }
        if (goalNode.position == start)
        {
            goalFound = false;
            backtrackDone = true;
        }
    }
}
