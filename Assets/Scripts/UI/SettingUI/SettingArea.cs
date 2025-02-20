

using UnityEngine;
using UnityEngine.UI;

public class SettingArea : Setting
{

    [SerializeField] private Button OkBTN;
    [SerializeField] private Button backBTN;

    private void Start()
    {
        OkBTN.onClick.AddListener(ChangeSound);
        backBTN.onClick.AddListener(CloseUI);
    }

}

