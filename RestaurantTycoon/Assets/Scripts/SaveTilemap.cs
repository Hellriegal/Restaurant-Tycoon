using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
using System;
using System.Runtime.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveTilemap : MonoBehaviour
{
    tileLocate locate;
    List<tileLocate.TileInfo> list;
    public Tile data;
    // Start is called before the first frame update
    void Start()
    {
        locate = GetComponent<tileLocate>();
    }

    // Update is called once per frame
    void Update()
    {
        initiateSave();
    }

    void initiateSave()
    {
        if (Input.GetKeyDown("s") & Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("save");
            save();
        }
    }

    void listTransfer()
    {

    }

    void save()
    {
         string destination = Application.persistentDataPath + "/save.dat";
         FileStream file;
 
         if(File.Exists(destination)) file = File.OpenWrite(destination);
         else file = File.Create(destination);

         locate.getAllTilePositions();
         list = locate.tiles;
         //TilemapSaveClass data = new TilemapSaveClass(list);
         BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(file, data);
         file.Close();
    }
}
