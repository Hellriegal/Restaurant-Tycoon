using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatePrefab : MonoBehaviour
{
    public GameObject objectToConvert;
    string obejctName;
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) & Input.GetKeyDown("s"))
        {
            save();
        }
        else if (Input.GetKeyDown("l"))
        {
            load();
        }
    }

    void save()
    {
        string localPath = "Assets/Resources/" + objectToConvert.name + ".prefab";
        obejctName = objectToConvert.name;
        if (File.Exists (localPath) == false)
        {
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(objectToConvert, localPath, InteractionMode.UserAction);
        }
        else
        {
            Debug.Log("exists");
            var obj = Resources.Load(obejctName, typeof(GameObject));
            DestroyImmediate(obj, true);
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(objectToConvert, localPath, InteractionMode.UserAction);
        }
        

    }

    void load()
    {
        if (objectToConvert.transform.parent)
        {
            Destroy (objectToConvert);
            var obj = Resources.Load(obejctName, typeof(GameObject));
            prefab = Instantiate(obj, objectToConvert.transform.parent.transform) as GameObject;
            objectToConvert = prefab;
        }
        else
        {
            prefab = Instantiate(Resources.Load(obejctName, typeof(GameObject))) as GameObject;
        }
    }
}
