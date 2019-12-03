using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string itemName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
}