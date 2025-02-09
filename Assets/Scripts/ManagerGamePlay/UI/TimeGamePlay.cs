using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class TimeGamePlay: MonoBehaviour
{

    private float timeStart = 0;


    private TMP_Text textDisplayTime;

    private void Start()
    {
        textDisplayTime = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        AddTime();
    }

    private void AddTime()
    {
        timeStart += Time.deltaTime;
        textDisplayTime.text = ConvertTime();
    }

    private string ConvertTime()
    {
        string result = "";
        int timeGet = Mathf.CeilToInt(timeStart);
        TimeSpan time = TimeSpan.FromSeconds(timeGet);
        result = time.ToString(@"mm\:ss");
        return result;
    }



}

