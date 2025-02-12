using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;

    [SerializeField] private Button login;
    [SerializeField] private Button register;

    private TMP_Text messageLabel;

    private void Start()
    {
        login.onClick.AddListener(LoginAccount);
        register.onClick.AddListener(ChangeToRegisterForm);
        messageLabel = transform.Find("Message").GetComponent<TMP_Text>();
    }

    

    private  void LoginAccount()
    {
        
        AccountData accountData = new AccountData { password = passwordInput.text, username = usernameInput.text };
        bool result = ManagerAccount.Instance.LoginAccount(accountData);
        String message = "";
        if(!result)
        {
            message = "Tài khoản không chính xác";
        }
        else
        {
            ManagerAccount.Instance.setDisactiveUI();

            ManagerScene.Instance.ChangeSceneLoading(StringScene.AreaScene);
        }
        messageLabel.text = message;
    }

    private void ChangeToRegisterForm()
    {
        ManagerAccount.Instance.ChangeRegisterForm();
    }

}

