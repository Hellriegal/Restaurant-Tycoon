﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for enabling the child of this scripts holder. Is also being used for handling of the runtimeBrush
public class enableChild : MonoBehaviour
{
    public GameObject[] objects;
    public enableBrush brushEnable;
    public RuntimeBrush runtimeBrush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enable(int reference)
    {
        disable();
        objects[reference].SetActive(true);
    }

    public void disable()
    {
        brushEnable.menuToggle();
        runtimeBrush.unconditionallyClearTile();
        foreach(GameObject menuType in objects)
        {
            menuType.SetActive(false);
        }
    }
}
