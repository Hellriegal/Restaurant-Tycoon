using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuntimeBrush : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePosition;
    public Camera camera;
    public Tilemap furniture;
    public Tilemap Hover;
    public Grid grid;
    public Tile tile;
    Vector3Int tileToClear;
    public List<Tile> tiles;
    int tileCounter = 0;

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
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
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
            furniture.SetTile(grid.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition)), tile);
        }
        if (Input.GetMouseButtonDown(1))
        {
            furniture.SetTile(grid.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition)), null);
        }
    }
}
