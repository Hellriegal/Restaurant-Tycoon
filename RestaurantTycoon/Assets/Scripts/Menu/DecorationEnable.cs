using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecorationEnable : MonoBehaviour
{
    Button button;
    DecorationItem decorationItem;
    public enableBrush brush;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(enable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enable()
    {
        decorationItem = GetComponent<getItemInfo>().decorationItem;
        brush.toggle(decorationItem.ItemName);
        brush.passTilemap(decorationItem.gridName);
    }
}
