using UnityEngine;

[CreateAssetMenu(fileName = "Menu Item", menuName = "Scriptable Objects/Menu Item", order = 1)]
public class MenuItem : ScriptableObject
{
    public string ItemName;
    public Sprite image;
}
