using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Loads tile to the decoration brush
public class loadToBrush : MonoBehaviour
{
    getItemInfo info;
    public RuntimeBrush runtimeBrush;
    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<getItemInfo>();
    }

    public void updateList()
    {
        runtimeBrush.loadTiles(info.decorationItem.tile);
    }
}
