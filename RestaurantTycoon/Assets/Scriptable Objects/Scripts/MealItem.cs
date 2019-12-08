using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Meal Item", menuName = "Scriptable Objects/Meal Item", order = 1)]
public class MealItem : ScriptableObject
{
    public string ItemName;
    public string DisplayName;
    public Sprite image;
    public float price;
}
