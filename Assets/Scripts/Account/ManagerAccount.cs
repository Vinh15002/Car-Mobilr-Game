
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


    private AccountData mainAccount;

    public AccountData MainAccout => mainAccount;


    private string mainKey;

    private List<string> KeyAccount = new List<string>();



    [HideInInspector]public List<Car> DataCar = new List<Car>();
    

    private void Start()
    {
       
       
        DBContext = FirebaseDatabase.DefaultInstance.RootReference;
        GetData();
        GetDataItemCar();
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
            account.diamond = 5000;
            account.coin = 5000;
            account.carDatas.Add(new AccountCarData(0, 0, 0));
            account.carDatas[0].IDSkinCars.Add(0);
            string json = JsonUtility.ToJson(account);
            var newReference = DBContext.Child("Users").Push();
                newReference.SetValueAsync(json);
            mainKey = newReference.Key;
            mainAccount = account;
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
        KeyAccount.Add(snapshot.Key);
        AccountData account = JsonUtility.FromJson<AccountData>(snapshot.Value.ToString());
        listAccounts.Add(account);

    }

    public bool LoginAccount(AccountData accountData)
    {
       
        for(int i = 0; i < listAccounts.Count; i++)
        {
            if (listAccounts[i].username == accountData.username && listAccounts[i].password == accountData.password)
            {
                mainAccount = listAccounts[i];
                mainKey = KeyAccount[i];
                return true;
            }
        }
        return false;
        
       
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


    public void UpdateName(string name)
    {
        mainAccount.name = name;
        string json = JsonUtility.ToJson(mainAccount);
        DBContext.Child("Users").Child(mainKey).SetValueAsync(json);
    }


    public bool BuyItemByDiamond(int amount)
    {

        if (mainAccount.diamond < amount) return false;
        else
        {
            
            return true;
        }
    }

    public bool BuyItemByGold(int amount)
    {

        if (mainAccount.diamond < amount) return false;
        else
        {
          
            return true;
        }
    }

    public void UpdateAccount(AccountData account)
    {
        string json = JsonUtility.ToJson(account);
        DBContext.Child("Users").Child(mainKey).SetValueAsync(json);
    }


    private void GetDataItemCar()
    {

        DBContext.Child("ItemCar").ChildAdded += AddDataCar; // Assuming GetValueAsync returns a Task<DataSnapshot>


    }

    private void AddDataCar(object sender, ChildChangedEventArgs e)
    {

        var snapshot = e.Snapshot;

        Car cardata = JsonUtility.FromJson<Car>(snapshot.Value.ToString());
        DataCar.Add(cardata);
    }





}

