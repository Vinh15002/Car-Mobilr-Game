using Assets.Scripts.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private Transform needle;
    private Text text_km;


    private void Start()
    {
        needle = transform.Find("needele").transform;
        text_km = transform.Find("speed").GetComponent<Text>(); 
    }




    private void OnEnable()
    {
        SpeedCarEvent.speedCarUI += ChangeSpeedUI;
    }

   

    private void OnDisable()
    {
        SpeedCarEvent.speedCarUI -= ChangeSpeedUI;
    }

    private void ChangeSpeedUI(float speed, float maxSpeed)
    {
        text_km.text = speed.ToString() + " km/h";
   
        float r = ratio(0, maxSpeed, speed);
       
        float rotate = FindValueRorate(33, -210, r);
       

        needle.rotation = Quaternion.Euler(0,0,Mathf.RoundToInt(rotate));

    }


    private float ratio(float a, float b, float x)
    {
        return (a-x)/(x-b);
    }

    private float FindValueRorate(float a, float b, float ratio)
    {
        return (a + ratio * b) / (ratio + 1);


    }














}
