using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveTilemap : MonoBehaviour
{
    [System.Serializable]
    public struct TileSaveInfo
    {
        public string tileName;
        public Vector3Int position;
        public TileSaveInfo(string name, Vector3Int pos)
        {
            tileName = name;
            position = pos;
        }
    }

    public Tilemap tilemap;
    tileLocate locate;
    public List<TileSaveInfo> tileSaves;
    // Start is called before the first frame update
    void Start()
    {
        locate = tilemap.GetComponent<tileLocate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            save();
        }
        else if (Input.GetKeyDown("l"))
        {
            load();
        }
    }

    void save()
    {
        Debug.Log("save");
        locate.getAllTilePositions();
        for (int i = 0; i < locate.tiles.Count; i++)
        {
            tileSaves.Add(new TileSaveInfo(locate.tiles[i].tileType.name, locate.tiles[i].position));
        }
    }

    void load()
    {
        Debug.Log("load");
        for (int i = 0; i < tileSaves.Count; i++)
        {
            Tile tile;
            tile = Resources.Load<Tile>("Furniture/tiles/"+tileSaves[i].tileName);
            tilemap.SetTile(tileSaves[i].position, tile);
        }
    }
}
