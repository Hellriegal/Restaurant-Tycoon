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
    bool getMouse = false;
    Vector3Int tileToClear;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hover();
        paint();
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

    void paint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            furniture.SetTile(grid.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition)), tile);
        }
    }
}
