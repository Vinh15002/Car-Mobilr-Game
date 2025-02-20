


using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectedScene: MonoBehaviour
{
    public Button back;
    public Button Practice;
    public Button Champion;
    public Button Multiplay;



    private void Start()
    {
        back.onClick.AddListener(BackScene);
        Champion.onClick.AddListener(ChangeToChampion);
        Practice.onClick.AddListener(ChangeToPractieScene);
        Multiplay.onClick.AddListener(ChangeToMultiplayerScene);
    }

    private void ChangeToMultiplayerScene()
    {
        throw new NotImplementedException();
    }

    private void ChangeToPractieScene()
    {
        ManagerScene.Instance.ChangeSceneLoading(StringScene.PracticeMap);
    }

    private void ChangeToChampion()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.ChampionScene);
    }

    private void BackScene()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.AreaScene);
    }

}

