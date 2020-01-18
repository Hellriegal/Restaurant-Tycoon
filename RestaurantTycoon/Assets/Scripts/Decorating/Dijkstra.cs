using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class Dijkstra : MonoBehaviour
{
    public tileLocate locate;
    

    public Vector3Int startPos;
    public Vector3Int goal;
    public TileBase obstacle;
    Node goalNode;

    bool backtrackDone = true;
    
    [Serializable]
    public struct Node
    {
        public int TotalCost;
        public List<Vector3Int> path;
        public Vector3Int position;
        public Node(int cost, Vector3Int pos, List<Vector3Int> prePos)
        {
            TotalCost = cost;
            position = pos;
            path = prePos;
        }
    }
    Tilemap tilemap;
    GridLayout gridLayout;

    public List<Vector3Int> previousPositions;
    public List<Node> checkQueue;
    Node previousNode;
    public List<Node> nextNodes;
    Node currentNode;
    public List<Vector3Int> updatePath;
    public List<Node> checkedNodes;
    
    void Start()
    {
        addTilesToPrevious();
        previousPositions.Add(startPos);
        checkQueue.Add(new Node(0, startPos, new List<Vector3Int> {startPos}));
        currentNode = checkQueue[0];
        previousNode = checkQueue[0];
        tilemap = GetComponent<Tilemap>();
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        if (currentNode.position != goal)
        {
            NodeCheck();
        }
    }

    void addTilesToPrevious()
    {
        for (int i = 0; i < locate.tilesPos.Count(); i++)
        {
            previousPositions.Add(locate.tilesPos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (backtrackDone == false)
        {
            backtrack();
        }
    }

    void NodeCheck()
    {
        for (int i = 0; i < checkQueue.Count(); i++)
        {
            surroundingNode(checkQueue[i]);
            for (int j = 0; j < nextNodes.Count(); j++)
            {
                if (nextNodes[j].position == goal)
                {
                    getGoalNode();
                    i = checkQueue.Count();
                    break;
                }
                checkQueue.Add(nextNodes[j]);
            }
        }
    }

    //Checks surrounding nodes and adds to the list "nextNodes" those that are to be checked next
    void surroundingNode(Node curNode)
    {
        currentNode = curNode;
        nextNodes.Clear();

        Vector3Int left = new Vector3Int(currentNode.position.x -1, currentNode.position.y, currentNode.position.z);
        Vector3Int right = new Vector3Int(currentNode.position.x +1, currentNode.position.y, currentNode.position.z);
        Vector3Int down = new Vector3Int(currentNode.position.x, currentNode.position.y -1, currentNode.position.z);
        Vector3Int up = new Vector3Int(currentNode.position.x, currentNode.position.y +1, currentNode.position.z);

        //PreviousNode
            if (left != previousNode.position)
            {
                nextNodes.Add(new Node(currentNode.TotalCost+1, left, new List<Vector3Int> {currentNode.position}));
            }
            if (right != previousNode.position)
            {
                nextNodes.Add(new Node(currentNode.TotalCost+1, right, new List<Vector3Int> {currentNode.position}));
            }
            if (down != previousNode.position)
            {
                nextNodes.Add(new Node(currentNode.TotalCost+1, down, new List<Vector3Int> {currentNode.position}));
            }
            if (up != previousNode.position)
            {
                nextNodes.Add(new Node(currentNode.TotalCost+1, up, new List<Vector3Int> {currentNode.position}));
            }
        
        //previous positions
        for (int j = 0; j < previousPositions.Count(); j++)
        {
            for (int i = 0; i < nextNodes.Count(); i++)
            {
                if (nextNodes[i].position == previousPositions[j])
                {
                    nextNodes.RemoveAt(i);
                }
            }
        }
        //PathUpdate
        for (int i = 0; i < nextNodes.Count(); i++)
        {
            checkedNodes.Add(nextNodes[i]);
        }
        //add to previous positions
        for (int i = 0; i < nextNodes.Count(); i++)
        {
            previousPositions.Add(nextNodes[i].position);
            Debug.DrawLine(gridLayout.CellToWorld(startPos), gridLayout.CellToWorld(goal), Color.blue, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x+1,nextNodes[i].position.y,nextNodes[i].position.z)), gridLayout.CellToWorld(nextNodes[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x,nextNodes[i].position.y+1,nextNodes[i].position.z)), gridLayout.CellToWorld(nextNodes[i].position), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x+1,nextNodes[i].position.y+1,nextNodes[i].position.z)), gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x+1,nextNodes[i].position.y,nextNodes[i].position.z)), Color.red, 1);
            Debug.DrawLine(gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x+1,nextNodes[i].position.y+1,nextNodes[i].position.z)), gridLayout.CellToWorld(new Vector3Int(nextNodes[i].position.x,nextNodes[i].position.y+1,nextNodes[i].position.z)), Color.red, 1);
        }
        checkedNodes.Distinct();
    }
    
    void backtrack()
    {
        if (goalNode.path[0] != goal)
        {
            for (int i = 0; i < checkedNodes.Count(); i++)
            {
                if (checkedNodes[i].position == goalNode.path[0])
                {
                    Debug.DrawLine(gridLayout.CellToWorld(goalNode.position), gridLayout.CellToWorld(checkedNodes[i].position), Color.green, 10);
                    goalNode = checkedNodes[i];
                    break;
                }
            }
        }
        else if (goalNode.path[0] == goal)
        {
            Debug.Log("Done");
            Debug.DrawLine(gridLayout.CellToWorld(goalNode.position), gridLayout.CellToWorld(goalNode.path[0]), Color.green, 10);
            backtrackDone = true;
        }
    }

    void getGoalNode()
    {
        for (int i = 0; i < checkedNodes.Count(); i++)
        {
            if (checkedNodes[i].position == goal)
            {
                goalNode = checkedNodes[i];
            }
        }
        backtrackDone = false;
    }

}
