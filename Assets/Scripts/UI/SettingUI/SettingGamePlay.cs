
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingGamePlay : Setting
{
    public Button SettingBTN;
    public Button BackBTN;


    [Header("Menu Button")]
    public Button Resume;
    public Button Restart;
    public Button Apply;

    private void Start()
    {
        SettingBTN.onClick.AddListener(DisplayUI);
        BackBTN.onClick.AddListener(CloseUI);
        Resume.onClick.AddListener(CloseUI);
        Restart.onClick.AddListener(RestartScene);
        Apply.onClick.AddListener(this.ChangeSound);
    }

    private void RestartScene()
    {
        Time.timeScale = 1;
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.Map01);
    }

    private void DisplayUI()
    {
        UI.SetActive(true);
        Time.timeScale = 0;
    }

    protected override void CloseUI()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
       
    }

}

