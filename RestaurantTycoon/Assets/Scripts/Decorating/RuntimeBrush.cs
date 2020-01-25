using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuntimeBrush : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePosition;
    public Camera myCamera;
    public Tilemap[] tilemaps;
    public Tilemap tilemap;
    public Tilemap Hover;
    public Grid grid;
    public Tile tile;
    Vector3Int tileToClear;
    public List<Tile> tiles;
    int tileCounter = 0;
    PurchasePass purchasePass;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hover();
        paint();
        changeActiveTile();
    }

    public void loadTiles(List<Tile> tilesToLoad)
    {
        tiles.Clear();
        tileCounter = 0;
        tiles = new List<Tile>(tilesToLoad);
        tile = tiles[0];
    }

    public void getTilemap(string tilemapName)
    {
        switch (tilemapName)
        {
            case "Furniture":
            tilemap = tilemaps[0];
            break;

            case "Floor":
            tilemap = tilemaps[1];
            break;
        }
    }


    void changeActiveTile()
    {
        
        if (Input.GetKeyDown("r") & Input.GetKey(KeyCode.LeftShift))
        {
            if (tileCounter != 0)
            {
                tileCounter--;
            }
            else
            {
                tileCounter = tiles.Count-1;
            }
            tile = tiles[tileCounter];
        }
        else if (Input.GetKeyDown("r"))
        {
            if (tileCounter != (tiles.Count - 1))
            {
                tileCounter++;
            }
            else
            {
                tileCounter = 0;
            }
            tile = tiles[tileCounter];
        }
    }

    void hover()
    {
            mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
            clearTile();
            tileToClear = grid.WorldToCell(mousePosition);
            Hover.SetTile(grid.WorldToCell(mousePosition), tile);
    }

    void clearTile()
    {
        if (mousePosition != tileToClear & tileToClear != null)
        {
            Hover.SetTile(tileToClear, null);
        }
    }

    public void unconditionallyClearTile()
    {
        Hover.ClearAllTiles();
    }

    void paint()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (Input.GetMouseButtonDown(0) & hit == false)
        {
            tilemap.SetTile(grid.WorldToCell(myCamera.ScreenToWorldPoint(Input.mousePosition)), tile);

        }
        if (Input.GetMouseButtonDown(1))
        {
            tilemap.SetTile(grid.WorldToCell(myCamera.ScreenToWorldPoint(Input.mousePosition)), null);
        }
    }
}
