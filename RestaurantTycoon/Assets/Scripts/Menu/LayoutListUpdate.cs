using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutListUpdate : MonoBehaviour
{
    List<MenuItem> layoutList;
    LayoutManager layoutManager;
    public MealData mData;
    // Start is called before the first frame update
    void Start()
    {
        layoutManager = GetComponent<LayoutManager>();
        layoutList = layoutManager.Items;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateList(MenuItem item)
    {
            if (layoutList.Contains(item) == false)
            {
                layoutList.Add(item);
            }
            else
            {
                layoutList.Remove(item);
            }
        layoutManager.Start();
        layoutManager.pageNumberReset();
    }
}
