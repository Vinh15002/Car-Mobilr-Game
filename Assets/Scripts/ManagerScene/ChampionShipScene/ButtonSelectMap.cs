
using System;
using UnityEngine;
using UnityEngine.UI;


public  class ButtonSelectMap: MonoBehaviour
{
    public Button map1;


    private void Start()
    {
        map1.onClick.AddListener(ChangeToMap1);
    }

    private void ChangeToMap1()
    {
        ManagerScene.Instance.ChangeSceneLoading(StringScene.Map01);
    }
}

