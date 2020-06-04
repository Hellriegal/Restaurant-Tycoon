using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manages data for the decoration menu
public class FurnitureCategory : MonoBehaviour
{
    public LayoutManager layoutManager;
    Button button;
    public List<DecorationItem> Counters;
    public List<DecorationItem> TablesChairs;
    public List<DecorationItem> Utility;
    public List<DecorationItem> FloorTiles;
    public List<DecorationItem> Decoration;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeList(string listName)
    {
        switch(listName)
        {
            case "Counters":
            {
                layoutManager.decorationItems = new List<DecorationItem>(Counters);
            }
            break;
            case "TablesChairs":
            {
                layoutManager.decorationItems = new List<DecorationItem>(TablesChairs);
            }
            break;
            case "Utility":
            {
                layoutManager.decorationItems = new List<DecorationItem>(Utility);
            }
            break;
            case "FloorTiles":
            {
                layoutManager.decorationItems = new List<DecorationItem>(FloorTiles);
            }
            break;
            case "Decoration":
            {
                layoutManager.decorationItems = new List<DecorationItem>(Decoration);
            }
            break;
        }
        layoutManager.Start();
        layoutManager.pageNumberReset();
    }
}
