using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getItemInfo : MonoBehaviour
{
    public MenuItem menuItem;
    public Text displayName;
    public string itemName;
    public Image image;

    public void Start()
    {
        displayName.text = menuItem.DisplayName;
        itemName = menuItem.ItemName;
        image.sprite = menuItem.image;
    }

    
}
