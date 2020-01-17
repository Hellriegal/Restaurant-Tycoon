using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class tileLocate : MonoBehaviour
{
    [Serializable]
    public struct TileInfo
    {
        public TileBase tileType;
        public Vector3Int position;
        public TileInfo(TileBase tile, Vector3Int pos)
        {
            tileType = tile;
            position = pos;
        }
    }
    [Serializable]
    public struct TileCandidate
    {
        public Vector3Int position;
        public float cost;
        public TileCandidate(Vector3Int pos, float dis)
        {
            position = pos;
            cost = dis;
        }
    }

    Tilemap tilemap;
    GridLayout gridLayout;

    public List<TileInfo> tiles;
    public List<TileCandidate> nextPositions;
    public List<float> nextPosCost;

    public TileBase obstacle;
    
    Vector3Int start = new Vector3Int(0,0,0);
    [SerializeField]
    Vector3Int goal = new Vector3Int(10,15,0);
    Vector3Int currentPos = new Vector3Int(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        getAllTilePositions();
        TileInfo temp = new TileInfo(tilemap.GetTile(new Vector3Int(1,1,0)), new Vector3Int(1,1,0));
        Debug.DrawLine(gridLayout.CellToWorld(start), gridLayout.CellToWorld(goal), Color.blue, Mathf.Infinity);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPos != goal)
        {
            pathFind();
        }
    }

    public void getAllTilePositions()
    {
        Vector3Int startingPosition = new Vector3Int(tilemap.cellBounds.position.x, tilemap.cellBounds.position.y, tilemap.cellBounds.position.z);
        Vector3Int endPosition = new Vector3Int(tilemap.cellBounds.position.x + (tilemap.cellBounds.size.x -1), tilemap.cellBounds.position.y + (tilemap.cellBounds.size.y -1), tilemap.cellBounds.position.z + (tilemap.cellBounds.size.z -1));

        for (int i = startingPosition.x; i <= endPosition.x; i++)
        {
            for (int j = startingPosition.y; j <= endPosition.y; j++)
            {
                tiles.Add (new TileInfo (tilemap.GetTile(new Vector3Int(i, j, 0)), new Vector3Int(i, j, 0)));
            }
        }
    }

    public float distanceFromPoint(Vector3Int start, Vector3Int goal)
    {
        float distance = 0;
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(start.x - goal.x), 2) + Mathf.Pow(Mathf.Abs(start.y - goal.y), 2));
        return distance;
    }

    public void pathFind()
    {
        Vector3Int initStart = currentPos;
        nextPositions.Clear();

        nextPositions.Add(new TileCandidate (new Vector3Int (currentPos.x -1, currentPos.y, 0), ((distanceFromPoint(new Vector3Int (currentPos.x -1, currentPos.y, 0), goal))) ));
        nextPositions.Add(new TileCandidate (new Vector3Int (currentPos.x +1, currentPos.y, 0), ((distanceFromPoint(new Vector3Int (currentPos.x +1, currentPos.y, 0), goal))) ));
        nextPositions.Add(new TileCandidate (new Vector3Int (currentPos.x, currentPos.y -1, 0), ((distanceFromPoint(new Vector3Int (currentPos.x, currentPos.y -1, 0), goal))) ));
        nextPositions.Add(new TileCandidate (new Vector3Int (currentPos.x, currentPos.y +1, 0), ((distanceFromPoint(new Vector3Int (currentPos.x, currentPos.y +1, 0), goal))) ));
        
        for (int i = 0; i < 4; i++)
        {
            if (tilemap.GetTile(nextPositions[i].position) != obstacle)
            {
                nextPosCost.Add(nextPositions[i].cost);
            }
            else if (tilemap.GetTile(nextPositions[i].position) != obstacle)
            {
                Debug.Log("Hit");
            }
        }

        float lowestCost = nextPosCost.Min();
        for (int i = 0; i < nextPositions.Count; i++)
        {
            if (nextPositions[i].cost == lowestCost)
            {
                currentPos = nextPositions[i].position;
            }
        }
        Debug.DrawLine(gridLayout.CellToWorld(initStart), gridLayout.CellToWorld(currentPos), Color.red, Mathf.Infinity);
    }
}
