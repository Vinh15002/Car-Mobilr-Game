using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour
{
    private TMP_Text textRank;

    private void Start()
    {
        textRank = GetComponent<TMP_Text>();
        RankEvent.updateRank += UpdateLabel;
    }
    private void OnDisable()
    {
        RankEvent.updateRank -= UpdateLabel;
    }
    private void UpdateLabel(int pos)
    {
        textRank.text = (pos ) + "";
    }

    


}

