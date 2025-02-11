

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerBar: MonoBehaviour
{
    public List<Sprite> listSprite;

    [SerializeField] private GameObject power;






    [ContextMenu("Test")]
    public void ChangePower(int index)
    {
        if (index < 1 || index > 6) return;
        power.GetComponent<Image>().sprite = listSprite[index-1];
    }



}

