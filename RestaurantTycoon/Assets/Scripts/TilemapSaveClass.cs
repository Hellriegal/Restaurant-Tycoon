using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TilemapSaveClass
{
    public List<tileLocate.TileInfo> Info;
    public TilemapSaveClass(List<tileLocate.TileInfo> listOfInfo)
    {
        Info = listOfInfo;
    }
}
