using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the decoration brush to be used
public class enableBrush : MonoBehaviour
{
    RuntimeBrush brush;
    bool isTrue = false;
    string decorationItemName = "null";
    [SerializeField]
    public GameObject FurnitureMenu;
    // Start is called before the first frame update
    void Start()
    {
        brush = GetComponent<RuntimeBrush>();
        brush.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        disableBursh();
    }

    public void disableBursh()
    {
        if (FurnitureMenu.activeSelf == false)
        {
            brush.enabled = false;
        }
    }

    public void toggle(string itemName)
    {
        if (isTrue == false & itemName != decorationItemName)
        {                
            brush.enabled = true;
            isTrue = true;
        }
        else if (isTrue == true & itemName == decorationItemName)            
        {
            brush.enabled = false;
            isTrue = false;
        }
        if (itemName != decorationItemName)
        {
            decorationItemName = itemName;
        }
    }

    public void passTilemap(string tilemapName)
    {
        brush.getTilemap(tilemapName);
    }

    public void menuToggle()
    {
        if (isTrue == false)
        {
            brush.enabled = true;
            isTrue = true;
        }
        else
        {
            brush.enabled = false;
            isTrue = false;
        }
    }
}
