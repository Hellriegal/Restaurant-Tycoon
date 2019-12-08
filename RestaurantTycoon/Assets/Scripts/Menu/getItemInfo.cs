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
    public Text noMoneyText;
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

    public void noMoney(bool ifTrue)
    {
        if (itemName != "blank")
        {
            if (ifTrue == true)
            {
                noMoneyText.enabled = true;
                button.interactable = false;
            }
            else
            {
                noMoneyText.enabled = false;
                button.interactable = true;
            }   
        }
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
