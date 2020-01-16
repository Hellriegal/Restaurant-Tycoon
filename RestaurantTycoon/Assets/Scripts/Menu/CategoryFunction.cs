using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryFunction : MonoBehaviour
{
    Button button;
    [SerializeField]
    string listName = "Entrees";
    public MealLayoutUpdate llU;
    public SelectedMealUpdate selectedMealUpdate;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeList()
    {
        llU.updateList(listName);
        selectedMealUpdate.updateList(listName);
    }
}
