
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaScene : MonoBehaviour
{
    public Button ShopBTN;
    public Button PlayBTN;
    public static AreaScene Instance;
    private AccountData account;
    [SerializeField] private GameObject NamePlayer;
    [SerializeField] private TMP_Text nameAvatar;


    private void Start()
    {
        Instance = this;
        account = ManagerAccount.Instance.MainAccout;
        ProcessData();
        ShopBTN.onClick.AddListener(ChangeShopScene);
        PlayBTN.onClick.AddListener(ChangePlayScene);


    }

    private void ChangePlayScene()
    {
        ManagerScene.Instance.ChangeSceneLoading(StringScene.MenuSelectScene);
    }

    private void ChangeShopScene()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.GargareScene);
    }

    private void ProcessData()
    {
        if(account.name == "?????")
        {
            NamePlayer.SetActive(true);
        }
        else
        {
            nameAvatar.text = account.name;
        }
        ResourceEvent.updateResource?.Invoke(account.diamond, account.coin);

    }


    public void ChangeNameAccount(string name)
    {
        nameAvatar.text = name;
        ManagerAccount.Instance.UpdateName(name);
        NamePlayer.SetActive(false);


    }



}

