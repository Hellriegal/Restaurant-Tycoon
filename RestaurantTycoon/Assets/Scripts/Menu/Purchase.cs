using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class Purchase : MonoBehaviour
{
    public PlayerStats playerStats;
    public InventoryData inventoryData;
    AudioSource audio;

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

