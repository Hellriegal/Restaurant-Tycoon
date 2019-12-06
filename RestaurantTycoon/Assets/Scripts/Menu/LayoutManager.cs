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

    void Start()
    {
        myTransform = canvas.GetComponent<Transform>();
        assignItem();
    }

    // Update is called once per frame
    void Update()
    {
        //nextPage();
        
    }

    void assignItem()
    {
        foreach (Transform child in myTransform)
        {
            Debug.Log(child.GetSiblingIndex());
        }
    }

    void nextPage()
    {
        if (Input.GetKey("left"))
        {
            getItemInfo itemInfo = o11.GetComponent<getItemInfo>();
            PurchasePass purchasePass = o11.GetComponent<PurchasePass>();
            itemInfo.menuItem = basil;
            itemInfo.Start();
            purchasePass.getItemName();
        }
        if (Input.GetKey("right"))
        {
            getItemInfo itemInfo = o11.GetComponent<getItemInfo>();
            PurchasePass purchasePass = o11.GetComponent<PurchasePass>();
            itemInfo.menuItem = potato;
            itemInfo.Start();
        }
    }
}
