using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableBrush : MonoBehaviour
{
    RuntimeBrush brush;
    bool isTrue = false;
    // Start is called before the first frame update
    void Start()
    {
        brush = GetComponent<RuntimeBrush>();
        brush.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enable()
    {
        if (isTrue == false)
        {
            brush.enabled = true;
            isTrue = true;
        }
        else
        {
            brush.enabled = false;
            isTrue = false;
        }
    }
}
