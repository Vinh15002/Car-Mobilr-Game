using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class TimeGamePlay: MonoBehaviour
{
    public static TimeGamePlay Instance;

    private float timeGame = 0;

    public float TimeGame {  get { return timeGame; } }


    private TMP_Text textDisplayTime;

    private void Start()
    {
        Instance = this;
        textDisplayTime = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        AddTime();
    }

    private void AddTime()
    {
        timeGame += Time.deltaTime;
        textDisplayTime.text = ConvertTime();
    }

    public string ConvertTime()
    {
        string result = "";
        int timeGet = Mathf.CeilToInt(timeGame);
        TimeSpan time = TimeSpan.FromSeconds(timeGet);
        result = time.ToString(@"mm\:ss");
        return result;
    }





}

