using Firebase.Database;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class Register: MonoBehaviour
{
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private InputField re_enterPasswordInput;

    [SerializeField] private Button loginBTN;

    private TMP_Text messageLabel;
    private Button back;

    

    private void Start()
    {

        messageLabel = transform.Find("Message").GetComponent<TMP_Text>();
        back = transform.Find("Back").GetComponent<Button>();
        back.onClick.AddListener(() => ManagerAccount.Instance.ChangeLoginForm());
        loginBTN.onClick.AddListener(RegisterAccount);
    }

    private void RegisterAccount()
    {
        string UserName = usernameInput.text;
        string Password = passwordInput.text;
        string RePassword = re_enterPasswordInput.text;

        string Message = "";
        if(Password.Length <4)
        {
            Message = "Mật khẩu phải có độ dài lớn hơn 4";
            
        }
        else if (Password != RePassword)
        {
            Message = "Mật khẩu nhập lại chưa trùng lặp";
        }
        else
        {
            AccountData accountData = new AccountData {username = UserName, password = Password };

            bool success =  ManagerAccount.Instance.RegisterAccount(accountData);
            
            if(!success)
            {
                Message = "Tên tài khoản đã được sử dụng";
            }
            else
            {
                ManagerAccount.Instance.setDisactiveUI();
                ManagerScene.Instance.ChangeSceneLoading(StringScene.AreaScene);
            }
            
        }
        messageLabel.text = Message;


    }



}

