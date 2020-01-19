using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
     private Vector3 startMousePos;
     public float minXPosition;
     public float maxXPosition;
     public float minYPosition;
     public float maxYPosition;

     void Update() 
     {
         if (Input.GetMouseButtonDown (2)) 
         {
             startMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             startMousePos.z = 0.0f;
         }
         if (Input.GetMouseButton (2)) 
         {
             Vector3 nowMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             nowMousePos.z = 0.0f;
             transform.position += startMousePos - nowMousePos;
         }
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXPosition, maxXPosition), transform.position.y, transform.position.z);
         transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minYPosition, maxYPosition), transform.position.z);
     }
 }
