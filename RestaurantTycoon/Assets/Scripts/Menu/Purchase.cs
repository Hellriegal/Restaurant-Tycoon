using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public IngredientPrices ingredientPrices;
    public PlayerStats playerStats;
    public InventoryData inventoryData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkPrice(string itemName)
    {
        if (itemName != null)
        {
            switch(itemName)
            {
                case "Potato":
                    if (ingredientPrices.Potato < playerStats.Money)
                    {
                        inventoryData.Potato++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Potato;
                    };
                    break;
            }
            
        }
    }
}
