using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

//This scripts handles purchasing with reference to PlayerStats and Inventory data, as well as sound effects of the pruchasing process.
public class Purchase : MonoBehaviour
{
    public PlayerStats playerStats;
    public InventoryData inventoryData;
    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void buy()
    {
        audio.Play();
    }

    public void checkPrice(float itemPrice, string itemName)
    {
        if (playerStats.Money > 0 & itemName != null)
        {
            inventoryData.updateCount(itemName);
            playerStats.Money = playerStats.Money - itemPrice;
            buy();
        }
    }
}

