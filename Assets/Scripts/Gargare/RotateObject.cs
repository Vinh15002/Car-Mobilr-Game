using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // T?c ?? xoay

    private Vector2 touchStartPos;

    public ControlMode mode;

    void Update()
    {
        if(mode == ControlMode.Button)
        {
            OnAndroid();
        }
        else
        {
            OnPC();
        }
       
        
    }

    private void OnPC()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            touchStartPos = Input.mousePosition; 
        }
        else if (Input.GetMouseButton(0)) 
        {
            Vector2 mouseDeltaPos = (Vector2 )Input.mousePosition - touchStartPos; 

            
            transform.Rotate(Vector3.up * -mouseDeltaPos.x * rotationSpeed * Time.deltaTime);

            touchStartPos = (Vector2)Input.mousePosition; 
        }
    }

    private void OnAndroid()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDeltaPos = touch.position - touchStartPos;

                    
                    transform.Rotate(Vector3.up * -touchDeltaPos.x * rotationSpeed * Time.deltaTime);

                    touchStartPos = touch.position;
                    break;
            }
        }
    }
}
