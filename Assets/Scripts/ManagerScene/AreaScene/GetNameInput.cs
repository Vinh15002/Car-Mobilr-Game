using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GetNameInput:MonoBehaviour
{
    public InputField input;

    public Button ok;

    private void Start()
    {
        ok.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        string name = input.text;
        AreaScene.Instance.ChangeNameAccount(name);
    }
}

