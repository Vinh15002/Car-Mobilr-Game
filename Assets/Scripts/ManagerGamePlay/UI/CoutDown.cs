using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class CoutDown:MonoBehaviour
{
    public GameObject CoutDownObject;
    public GameObject UIObject;
    public TMP_Text text;
    private float time;



    private void OnEnable()
    {
        CountDownEvent.transferTime += ChangeTimeDislay;
    }

    

    private void OnDisable()
    {
        CountDownEvent.transferTime -= ChangeTimeDislay;
    }

    private void ChangeTimeDislay(float time)
    {
        if(time > 0)
        {
            int Display = Mathf.FloorToInt(time);
            text.text = Display.ToString();
        } 
        else
        {
            CoutDownObject.SetActive(false);
            UIObject.SetActive(true);
        }
        
    }
}

