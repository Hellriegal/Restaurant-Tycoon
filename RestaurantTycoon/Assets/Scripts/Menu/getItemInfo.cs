using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getItemInfo : MonoBehaviour
{
    public MenuItem menuItem;
    public DecorationItem decorationItem;
    public Text displayName;
    public string itemName;
    public Image image;
    public Text noMoneyText;
    public Text price;
    public float priceValue;
    Button button;

    public void Start()
    {
        if (menuItem)
        {
        displayName.text = menuItem.DisplayName;
        itemName = menuItem.ItemName;
        image.sprite = menuItem.image;
        priceValue = menuItem.price;
        price.text = "$ " + priceValue.ToString();
        button = GetComponent<Button>();
        }
        else if (decorationItem)
        {
        displayName.text = decorationItem.DisplayName;
        itemName = decorationItem.ItemName;
        image.sprite = decorationItem.image;
        priceValue = decorationItem.price;
        price.text = "$ " + priceValue.ToString();
        button = GetComponent<Button>();
        }
    }

    public void Update()
    {
        lockButton();
    }

    public void noMoney(bool ifTrue)
    {
        if (itemName != "blank" & menuItem & noMoneyText)
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
        if (itemName == "blank" & button)
        {
            button.interactable = false;
        }
        else if (button)
        {
            button.interactable = true;
        }
    }

    
}
