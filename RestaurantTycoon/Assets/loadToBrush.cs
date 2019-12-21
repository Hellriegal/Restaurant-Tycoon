using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class loadToBrush : MonoBehaviour
{
    getItemInfo info;
    public RuntimeBrush runtimeBrush;
    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<getItemInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateList()
    {
        runtimeBrush.loadTiles(info.decorationItem.tile);
    }
}
