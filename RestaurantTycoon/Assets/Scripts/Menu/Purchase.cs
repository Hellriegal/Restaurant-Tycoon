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
                case "Basil":
                    if (ingredientPrices.Basil < playerStats.Money)
                    {
                        inventoryData.Basil++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Basil;
                    };
                    break;
                    case "Bread":
                    if (ingredientPrices.Bread < playerStats.Money)
                    {
                        inventoryData.Bread++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Bread;
                    };
                    break;
                    case "BreadCrumbs":
                    if (ingredientPrices.BreadCrumbs < playerStats.Money)
                    {
                        inventoryData.BreadCrumbs++;
                        playerStats.Money = playerStats.Money - ingredientPrices.BreadCrumbs;
                    };
                    break;
                    case "Butter":
                    if (ingredientPrices.Butter < playerStats.Money)
                    {
                        inventoryData.Butter++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Butter;
                    };
                    break;
                    case "Cabanossi":
                    if (ingredientPrices.Cabanossi < playerStats.Money)
                    {
                        inventoryData.Cabanossi++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Cabanossi;
                    };
                    break;
                    case "Cheese":
                    if (ingredientPrices.Cheese < playerStats.Money)
                    {
                        inventoryData.Cheese++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Cheese;
                    };
                    break;
                    case "Chicken":
                    if (ingredientPrices.Chicken < playerStats.Money)
                    {
                        inventoryData.Chicken++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Chicken;
                    };
                    break;
                    case "CoffeeBeans":
                    if (ingredientPrices.CoffeeBeans < playerStats.Money)
                    {
                        inventoryData.CoffeeBeans++;
                        playerStats.Money = playerStats.Money - ingredientPrices.CoffeeBeans;
                    };
                    break;
                    case "Corn":
                    if (ingredientPrices.Corn < playerStats.Money)
                    {
                        inventoryData.Corn++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Corn;
                    };
                    break;
                    case "Custard":
                    if (ingredientPrices.Custard < playerStats.Money)
                    {
                        inventoryData.Custard++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Custard;
                    };
                    break;
                    case "Dough":
                    if (ingredientPrices.Dough < playerStats.Money)
                    {
                        inventoryData.Dough++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Dough;
                    };
                    break;
                    case "Garlic":
                    if (ingredientPrices.Garlic < playerStats.Money)
                    {
                        inventoryData.Garlic++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Garlic;
                    };
                    break;
                    case "Ham":
                    if (ingredientPrices.Ham < playerStats.Money)
                    {
                        inventoryData.Ham++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Ham;
                    };
                    break;
                    case "IceCream":
                    if (ingredientPrices.IceCream < playerStats.Money)
                    {
                        inventoryData.IceCream++;
                        playerStats.Money = playerStats.Money - ingredientPrices.IceCream;
                    };
                    break;
                    case "Lemonade":
                    if (ingredientPrices.Lemonade < playerStats.Money)
                    {
                        inventoryData.Lemonade++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Lemonade;
                    };
                    break;
                    case "Peas":
                    if (ingredientPrices.Peas < playerStats.Money)
                    {
                        inventoryData.Peas++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Peas;
                    };
                    break;
                    case "Pepperoni":
                    if (ingredientPrices.Pepperoni < playerStats.Money)
                    {
                        inventoryData.Pepperoni++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pepperoni;
                    };
                    break;
                    case "Pineapple":
                    if (ingredientPrices.Pineapple < playerStats.Money)
                    {
                        inventoryData.Pineapple++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pineapple;
                    };
                    break;
                    case "Potato":
                    if (ingredientPrices.Potato < playerStats.Money)
                    {
                        inventoryData.Potato++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Potato;
                    };
                    break;
                    case "Pumpkin":
                    if (ingredientPrices.Pumpkin < playerStats.Money)
                    {
                        inventoryData.Pumpkin++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pumpkin;
                    };
                    break;
                    case "Steak":
                    if (ingredientPrices.Steak < playerStats.Money)
                    {
                        inventoryData.Steak++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Steak;
                    };
                    break;
                    case "Sugar":
                    if (ingredientPrices.Sugar < playerStats.Money)
                    {
                        inventoryData.Sugar++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Sugar;
                    };
                    break;
                    case "TeaLeaves":
                    if (ingredientPrices.TeaLeaves < playerStats.Money)
                    {
                        inventoryData.TeaLeaves++;
                        playerStats.Money = playerStats.Money - ingredientPrices.TeaLeaves;
                    };
                    break;
                    case "Tomato":
                    if (ingredientPrices.Tomato < playerStats.Money)
                    {
                        inventoryData.Tomato++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Tomato;
                    };
                    break;
                    case "TomatoBase":
                    if (ingredientPrices.TomatoBase < playerStats.Money)
                    {
                        inventoryData.TomatoBase++;
                        playerStats.Money = playerStats.Money - ingredientPrices.TomatoBase;
                    };
                    break;
            }
            
        }
    }
}
