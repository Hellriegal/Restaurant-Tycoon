using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
     private Vector3 startMousePos;
 
     void Update() {
         if (Input.GetMouseButtonDown (2)) {
             startMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             startMousePos.z = 0.0f;
         }
 
         if (Input.GetMouseButton (2)) {
             Vector3 nowMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
             nowMousePos.z = 0.0f;
             transform.position += startMousePos - nowMousePos;
         }
     }
 }
