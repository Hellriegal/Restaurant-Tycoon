using UnityEngine;

//The script to create a database of Player Statistics
[CreateAssetMenu(fileName = "Player Stats", menuName = "Scriptable Objects/Player Stats", order = 1)]
public class PlayerStats : ScriptableObject
{
   public float Money;

   public void addMoney(int amount)
   {
      Money = Money + amount;
   }
}
