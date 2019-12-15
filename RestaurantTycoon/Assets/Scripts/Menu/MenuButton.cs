using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject objectToEnable;
    Button thisButton;
    public enableChild ParentClass;
    [SerializeField]
    int menuReferenceNo = 0;

    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(enable);
        objectToEnable.SetActive(false);
    }

    public void enable()
    {
        if (!objectToEnable.activeSelf)
        {
            ParentClass.GetComponent<enableChild>().enable(menuReferenceNo);
        }
        else
        {
            ParentClass.GetComponent<enableChild>().disable();
        }
    }
}
