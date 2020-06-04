using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles camera drag via holding the scroll wheel button or the right click button
public class CameraDrag : MonoBehaviour
{
     private Vector3 startMousePos;
     public float minXPosition;
     public float maxXPosition;
     public float minYPosition;
     public float maxYPosition;

     void Update() 
     {
         drag();
     }

     void drag()
     {
         if (Input.GetMouseButtonDown (1) | Input.GetMouseButtonDown (2)) 
         {
             startMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             startMousePos.z = 0.0f;
         }
         if (Input.GetMouseButton (1) | Input.GetMouseButton (2)) 
         {
             Vector3 currentMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             currentMousePos.z = 0.0f;
             transform.position += startMousePos - currentMousePos;
         }
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXPosition, maxXPosition), transform.position.y, transform.position.z);
         transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minYPosition, maxYPosition), transform.position.z);
     }
 }
