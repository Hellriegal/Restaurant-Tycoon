using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableBrush : MonoBehaviour
{
    RuntimeBrush brush;
    bool isTrue = false;
    string decorationItemName = "null";
    // Start is called before the first frame update
    void Start()
    {
        brush = GetComponent<RuntimeBrush>();
        brush.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle(string itemName)
    {
        Debug.Log(isTrue + ". itemName = " + itemName + ". DecorationName = " + decorationItemName);
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
