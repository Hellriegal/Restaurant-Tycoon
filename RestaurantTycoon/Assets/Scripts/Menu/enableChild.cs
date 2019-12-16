﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableChild : MonoBehaviour
{
    public GameObject[] objects;
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
        foreach(GameObject menuType in objects)
        {
            menuType.SetActive(false);
        }
    }
}