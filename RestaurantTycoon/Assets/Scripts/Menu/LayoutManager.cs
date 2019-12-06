using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject o11;
    public MenuItem basil;
    public MenuItem potato;
    Transform myTransform;
    public MenuItem[] items;
    int counter = 0;
    int pageNumber = 0;

    void Start()
    {
        myTransform = canvas.GetComponent<Transform>();
        assignItem();
    }

    void Update()
    {
        nextPage();
    }

    void assignItem()
    {
        foreach (Transform child in myTransform)
        {
            int itemIndex = counter+(pageNumber*18);
            if (itemIndex > 24)
            {
                itemIndex = 24;
            }
            child.gameObject.GetComponent<getItemInfo>().menuItem = items[itemIndex];
            counter++;
            getItemInfo itemInfo = child.gameObject.GetComponent<getItemInfo>();
            PurchasePass purchasePass = child.gameObject.GetComponent<PurchasePass>();
            itemInfo.Start();
            purchasePass.getItemName();
        }
    }

    void nextPage()
    {
        if (Input.GetKey("left"))
        {
            counter = 0;
            if (pageNumber > 0)
            {
                pageNumber--;
            }
            assignItem();
        }
        if (Input.GetKey("right"))
        {
            counter = 0;
            if (pageNumber < 1)
            {
                pageNumber++;
            }
            assignItem();
        }
    }
}
