﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used to update the money UI element
public class Money : MonoBehaviour
{
    public PlayerStats playerStats;
    Text MoneyText; 

    void Start()
    {
        MoneyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMoney();
    }

    void updateMoney()
    {
        MoneyText.text = "$" + playerStats.Money;
    }
}
