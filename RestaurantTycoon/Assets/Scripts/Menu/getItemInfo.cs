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
    Button button;

    public void Start()
    {
        displayName.text = menuItem.DisplayName;
        itemName = menuItem.ItemName;
        image.sprite = menuItem.image;
        button = GetComponent<Button>();
    }

    public void Update()
    {
        lockButton();
    }

    public void lockButton()
    {
        if (itemName == "blank")
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    
}
