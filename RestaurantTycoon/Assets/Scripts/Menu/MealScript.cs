using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealScript : MonoBehaviour
{
    Button thisButton;
    public MealData data;
    MenuItem menuItem;
    public LayoutListUpdate layoutListUpdate;

    public void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(assign);
    }

    void Update()
    {
        
    }

    void assign()
    {
        menuItem = GetComponent<getItemInfo>().menuItem;
        data.addToList(menuItem);
        layoutListUpdate.updateList(menuItem);
    }
}
