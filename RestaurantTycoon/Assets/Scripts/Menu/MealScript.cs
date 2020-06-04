using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handles events of the meal menu, adding and removing items in lists in the Meal Data scriptable object
public class MealScript : MonoBehaviour
{
    Button thisButton;
    public MealData data;
    MenuItem menuItem;
    public SelectedMealUpdate selectedMealUpdate;


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
        data.addToList(menuItem, menuItem.menuType);
        selectedMealUpdate.updateList(menuItem.menuType);
    }
}
