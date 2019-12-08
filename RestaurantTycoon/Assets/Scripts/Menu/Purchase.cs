using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public IngredientPrices ingredientPrices;
    public PlayerStats playerStats;
    public InventoryData inventoryData;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buy()
    {
        audio.Play();
    }

    public void checkPrice(string itemName)
    {
        if (itemName != null & playerStats.Money > 0)
        {
            switch(itemName)
            {
                case "Basil":
                        inventoryData.Basil++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Basil;
                        buy();
                    break;
                    case "Bread":
                    
                    {
                        inventoryData.Bread++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Bread;
                        audio.Play();
                    };
                    break;
                    case "BreadCrumbs":
                    
                    {
                        inventoryData.BreadCrumbs++;
                        playerStats.Money = playerStats.Money - ingredientPrices.BreadCrumbs;
                        audio.Play();
                    };
                    break;
                    case "Butter":
                    
                    {
                        inventoryData.Butter++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Butter;
                        audio.Play();
                    };
                    break;
                    case "Cabanossi":
                    
                    {
                        inventoryData.Cabanossi++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Cabanossi;
                        audio.Play();
                    };
                    break;
                    case "Cheese":
                    
                    {
                        inventoryData.Cheese++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Cheese;
                        audio.Play();
                    };
                    break;
                    case "Chicken":
                    
                    {
                        inventoryData.Chicken++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Chicken;
                        audio.Play();
                    };
                    break;
                    case "CoffeeBeans":
                    
                    {
                        inventoryData.CoffeeBeans++;
                        playerStats.Money = playerStats.Money - ingredientPrices.CoffeeBeans;
                        audio.Play();
                    };
                    break;
                    case "Corn":
                    
                    {
                        inventoryData.Corn++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Corn;
                        audio.Play();
                    };
                    break;
                    case "Custard":
                    {
                        inventoryData.Custard++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Custard;
                        audio.Play();
                    };
                    break;
                    case "Dough":
                    {
                        inventoryData.Dough++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Dough;
                        audio.Play();
                    };
                    break;
                    case "Garlic":
                    {
                        inventoryData.Garlic++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Garlic;
                        audio.Play();
                    };
                    break;
                    case "Ham":
                    {
                        inventoryData.Ham++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Ham;
                        audio.Play();
                    };
                    break;
                    case "IceCream":
                    {
                        inventoryData.IceCream++;
                        playerStats.Money = playerStats.Money - ingredientPrices.IceCream;
                        audio.Play();
                    };
                    break;
                    case "Lemonade":
                    {
                        inventoryData.Lemonade++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Lemonade;
                        audio.Play();
                    };
                    break;
                    case "Peas":
                    {
                        inventoryData.Peas++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Peas;
                        audio.Play();
                    };
                    break;
                    case "Pepperoni":
                    {
                        inventoryData.Pepperoni++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pepperoni;
                        audio.Play();
                    };
                    break;
                    case "Pineapple":
                    {
                        inventoryData.Pineapple++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pineapple;
                        audio.Play();
                    };
                    break;
                    case "Potato":
                    {
                        inventoryData.Potato++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Potato;
                        audio.Play();
                    };
                    break;
                    case "Pumpkin":
                    {
                        inventoryData.Pumpkin++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Pumpkin;
                        audio.Play();
                    };
                    break;
                    case "Steak":
                    {
                        inventoryData.Steak++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Steak;
                        audio.Play();
                    };
                    break;
                    case "Sugar":
                    {
                        inventoryData.Sugar++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Sugar;
                        audio.Play();
                    };
                    break;
                    case "TeaLeaves":
                    {
                        inventoryData.TeaLeaves++;
                        playerStats.Money = playerStats.Money - ingredientPrices.TeaLeaves;
                        audio.Play();
                    };
                    break;
                    case "Tomato":
                    {
                        inventoryData.Tomato++;
                        playerStats.Money = playerStats.Money - ingredientPrices.Tomato;
                        audio.Play();
                    };
                    break;
                    case "TomatoBase":
                    {
                        inventoryData.TomatoBase++;
                        playerStats.Money = playerStats.Money - ingredientPrices.TomatoBase;
                        audio.Play();
                    };
                    break;
            }
            
        }
    }
}
