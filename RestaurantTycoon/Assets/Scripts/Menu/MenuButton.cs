using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    bool isActive = false;
    public GameObject objectToEnable;
    Button thisButton;

    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(enable);
        objectToEnable.SetActive(false);
    }

    public void enable()
    {
        if (isActive == false)
        {
            objectToEnable.SetActive(true);
            isActive = true;
        }
        else
        {
            objectToEnable.SetActive(false);
            isActive = false;
        }
    }
}
