

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerBar: MonoBehaviour
{
    public List<Sprite> listSprite;

    [SerializeField] private GameObject power;






    [ContextMenu("Test")]
    public void ChangeImage(int index)
    {
        if (index < 0 || index > 5) return;
        power.GetComponent<Image>().sprite = listSprite[index];
    }



}

