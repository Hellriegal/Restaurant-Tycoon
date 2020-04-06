using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;


//Gets all tiles in the tileMap

public class tileLocate : MonoBehaviour
{
    [System.Serializable]
    public struct TileInfo
    {
        public TileBase tileType;
        public Vector3Int position;
        public bool occupied;
        public TileInfo(TileBase tile, Vector3Int pos, bool isOccupied)
        {
            tileType = tile;
            position = pos;
            occupied = isOccupied;
        }
    }
    Tilemap tilemap;
    GridLayout gridLayout;

    public List<TileInfo> tiles;
    public List<Vector3Int> tilesPos;
    
    // Start is called before the first frame update
    public void Start()
    {
        tiles = new List<TileInfo>();
        tilesPos = new List<Vector3Int>();
        tilemap = GetComponent<Tilemap>();
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        getAllTilePositions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getAllTilePositions()
    {
        Vector3Int startingPosition = new Vector3Int(tilemap.cellBounds.position.x, tilemap.cellBounds.position.y, tilemap.cellBounds.position.z);
        Vector3Int endPosition = new Vector3Int(tilemap.cellBounds.position.x + (tilemap.cellBounds.size.x -1), tilemap.cellBounds.position.y + (tilemap.cellBounds.size.y -1), tilemap.cellBounds.position.z + (tilemap.cellBounds.size.z -1));

        for (int i = startingPosition.x; i <= endPosition.x; i++)
        {
            for (int j = startingPosition.y; j <= endPosition.y; j++)
            {
                if (tilemap.GetTile(new Vector3Int(i, j, 0)))
                {
                    tiles.Add (new TileInfo (tilemap.GetTile(new Vector3Int(i, j, 0)), new Vector3Int(i, j, 0), false));
                    tilesPos.Add(new Vector3Int(i, j, 0));
                }
            }
        }
    }
}
