
using TMPro;
using UnityEngine;

public class Position: MonoBehaviour
{
    private TMP_Text rank;
    private TMP_Text nameCar;
    private TMP_Text time;


    private void Awake()
    {
        rank = transform.Find("rank").GetComponent<TMP_Text>();
        nameCar = transform.Find("name").GetComponent<TMP_Text>();
        time = transform.Find("time").GetComponent <TMP_Text>();
    }


    public void SetContent(string rank, string name, string time)
    {
        this.rank.text = rank;
        this.nameCar.text = name;
        this.time.text = time;
    }
}

