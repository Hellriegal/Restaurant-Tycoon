using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//The script to create a generic decorationItem object
[CreateAssetMenu(fileName = "Decoration Item", menuName = "Scriptable Objects/DecorationItem", order = 1)]
public class DecorationItem : ScriptableObject
{
    public string ItemName;
    public string DisplayName;
    public Sprite image;
    public float price;
    public string menuType;
    public List<Tile> tile;
    public string gridName;
}
