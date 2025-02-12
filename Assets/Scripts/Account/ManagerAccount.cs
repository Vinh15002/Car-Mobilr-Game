
using Firebase.Database;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;


public class ManagerAccount : MonoBehaviour
{

    public static ManagerAccount Instance;

    DatabaseReference DBContext;


    private List<AccountData> listAccounts = new List<AccountData>();
    public  GameObject loginForm;
    public GameObject registerForm;
    

    

    private void Start()
    {
       
       
        DBContext = FirebaseDatabase.DefaultInstance.RootReference;
        GetData();
        
        Instance = this;
        
    }


    public bool RegisterAccount(AccountData account)
    {
      
        var item = listAccounts.FirstOrDefault(e => e.username == account.username);
        if (item != null)
        {
            return false;
        }
        else
        {
            account.name = "?????";
            account.diamond = 50;
            account.coin = 50;
            account.carDatas.Add(new AccountCarData(0, 0, 0));
            account.carDatas[0].IDSkinCars.Add(0);
            string json = JsonUtility.ToJson(account);
            DBContext.Child("Users").Push().SetValueAsync(json);
            return true;
        }
        
       
    }

    [ContextMenu("Test FireBase")]
    private void GetData()
    {
        
        DBContext.Child("Users").ChildAdded += AddAccount; // Assuming GetValueAsync returns a Task<DataSnapshot>
        
        
    }

    private void AddAccount(object sender, ChildChangedEventArgs e)
    {
       
        var snapshot = e.Snapshot;
        AccountData account = JsonUtility.FromJson<AccountData>(snapshot.Value.ToString());
        listAccounts.Add(account);
    }

    public bool LoginAccount(AccountData accountData)
    {
        AccountData account = listAccounts.FirstOrDefault(e => e.username == accountData.username && e.password == accountData.password);
        return account != null;
    }

    public void ChangeRegisterForm()
    {
        loginForm.SetActive(false);
        registerForm.SetActive(true);
    }

    public void ChangeLoginForm()
    {
        loginForm.SetActive(true);
        registerForm.SetActive(false);
    }



    public void setDisactiveUI()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }


}

