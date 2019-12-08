using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Menu Item", menuName = "Scriptable Objects/Menu Item", order = 1)]
public class MenuItem : ScriptableObject
{
    public string ItemName;
    public string DisplayName;
    public Sprite image;
    public float price;
}
