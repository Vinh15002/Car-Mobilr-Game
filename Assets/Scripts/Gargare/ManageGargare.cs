
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ManageGargare: MonoBehaviour
{


    public static ManageGargare Instance;
    [SerializeField] private Button LeftBTN;
    [SerializeField] private Button RightBTN;
    [SerializeField] private ChooseBTN ChooseBTN;
    [SerializeField] private ManagerColor managerColor;
    [SerializeField] private GameObject BuffSpeed;
    [SerializeField] private GameObject BuffPower;

    public List<ParticleSystem> effectUpdate;

    private int currentIndex = 0;
    private int currentSkin = 0;

    private List<Car> dataCar;

    
    private AccountData accountData;





    private void Start()
    {
        Instance = this;
        SetEffectOff();


        accountData = ManagerAccount.Instance.MainAccout;
        ResourceEvent.updateResource?.Invoke(accountData.diamond, accountData.coin);
        
        dataCar = new List<Car>();
        dataCar = ManagerAccount.Instance.DataCar;
        LeftBTN.onClick.AddListener(OnLeftClick);
        RightBTN.onClick.AddListener(OnRightClick);
        SetChooseCarBTN();
        managerColor.ChangeLock(GetListDataSkin());


    }

    
    

    private void OnLeftClick()
    {
        currentSkin = 0;
        currentIndex = currentIndex - 1 >= 0 ? currentIndex -1 : dataCar.Count - 1;
        SetcurrentCar();
    }

    private void OnRightClick()
    {
        currentSkin = 0;
        currentIndex = currentIndex + 1 <= dataCar.Count - 1 ? currentIndex + 1 : 0;
        SetcurrentCar();
    }


    public void SetcurrentCar()
    {
        
        ListCarDisplay.Instance.SetDisplayCar(currentIndex, currentSkin);
        
        managerColor.SetUpColor(dataCar[currentIndex].skinCars);
        managerColor.ChangeLock(GetListDataSkin());
        SetChooseCarBTN();
        ChooseBTN.setPriceBuyBTN(getPriceSkin());
        //SetChooseCar();

    }


    public void setSkin(int index)
    {
        currentSkin = index;
        SetcurrentCar();


    }





    public void SetChooseCarBTN()
    {
        int CarID = accountData.currentCarID;
        int CarSkin = accountData.currentCarSkinID;



        if (CarID == currentIndex && CarSkin == currentSkin)
        {
            ChooseBTN.SetGroupBTN();
            GetUpdateGold();
        }
        else if (CarID == currentIndex && GetListDataSkin().Contains(currentSkin))
        {
            ChooseBTN.SetSelectBTN();
            GetUpdateGold();


        }
        else if (GetAllCar().Contains(currentIndex) && GetListDataSkin().Contains(currentSkin))
        {
            ChooseBTN.SetSelectBTN();
            GetUpdateGold();
            
        }
        else
        {
            ChooseBTN.SetBuyBTN();
        }
        
    }


    
    
    public List<int> GetListDataSkin()
    {
        List<AccountCarData> Cars = accountData.carDatas;
        List<int> dataSkins = null ;
        foreach(AccountCarData data in Cars)
        {
            if(data.IDcar == currentIndex)
            {
                dataSkins = data.IDSkinCars;
                break;
            }
        }
        return dataSkins;

    }

    public List<int> GetAllCar()
    {
        
        List<int> dataCars = new List<int>();
        foreach(var data in accountData.carDatas)
        {
            dataCars.Add(data.IDcar);
        }
        return dataCars;
    }


    public int getPriceSkin()
    {
        if (!GetAllCar().Contains(currentIndex))
        {
            return (int)dataCar[currentIndex].Price;
            
        }
        else
        {
            int price = (int)dataCar[currentIndex].skinCars[currentSkin].Price;
            return price;
        }
    }

    public void GetUpdateGold()
    {
        if(GetAllCar().Contains(currentIndex))
        {
            int speedLevel = accountData.carDatas[currentIndex].currentSpeedLevel;
            int powerLevel = accountData.carDatas[currentIndex].currentBuffLevel;

            
            
            if (speedLevel != 5)
            {
                BuffSpeed.SetActive(true);
                int GOlDSpeed = this.dataCar[currentIndex].level.CoinSpeed[speedLevel + 1];
                UpgradeButtonEvent.changeTextSpeed?.Invoke(GOlDSpeed, speedLevel);
            }
            else
            {
                UpgradeButtonEvent.changeTextSpeed?.Invoke(0, speedLevel);
                BuffSpeed.SetActive(false);
                
            }
            if(powerLevel != 5)
            {
                BuffPower.SetActive(true);
                int GOLDPower = this.dataCar[currentIndex].level.CoinBuff[powerLevel + 1];
                UpgradeButtonEvent.changeTextPower?.Invoke(GOLDPower, powerLevel);
            }
            else
            {
                UpgradeButtonEvent.changeTextPower?.Invoke(0, powerLevel);
                BuffPower.SetActive(false);
            }
            
        }
        else
        {
            UpgradeButtonEvent.changeTextPower?.Invoke(0, 0);
            UpgradeButtonEvent.changeTextSpeed?.Invoke(0, 0);

        }
        
    }

    public void UpgradePower(int amount)
    {
        bool ok = ManagerAccount.Instance.BuyItemByGold(amount);
        if (ok)
        {
            SetEffectOn();
            int powerLevel = accountData.carDatas[currentIndex].currentBuffLevel;
            powerLevel++;
            accountData.coin -= amount;
            accountData.carDatas[currentIndex].currentBuffLevel = powerLevel;
            
            GetUpdateGold();
            ResourceEvent.updateResource?.Invoke(accountData.diamond, accountData.coin);
            ManagerAccount.Instance.UpdateAccount(accountData);
            

           
        }

        
    }

    public void UpgradeSpeed(int amount)
    {
        bool ok = ManagerAccount.Instance.BuyItemByGold(amount);
        if (ok)
        {
            SetEffectOn();
            int speedLevel = accountData.carDatas[currentIndex].currentSpeedLevel;
            speedLevel++;
            accountData.coin -= amount;
            accountData.carDatas[currentIndex].currentSpeedLevel = speedLevel;
        }
        GetUpdateGold();
        ResourceEvent.updateResource?.Invoke(accountData.diamond, accountData.coin);
        ManagerAccount.Instance.UpdateAccount(accountData);
    }

    public void BuyItem(int amount)
    {
        bool ok = ManagerAccount.Instance.BuyItemByDiamond(amount);
        if (!ok) return;
        accountData.diamond -= amount;
        if (!GetAllCar().Contains(currentIndex))
        {
            AccountCarData car = new AccountCarData(currentIndex, 0, 0);
            accountData.carDatas.Add(car);
            accountData.carDatas[currentIndex].IDSkinCars.Add(0);
            
            this.GetUpdateGold();
            SetcurrentCar();
            


        }
        else
        {
            accountData.carDatas[currentIndex].IDSkinCars.Add(this.currentSkin);

        }
        managerColor.ChangeLock(GetListDataSkin());
        ResourceEvent.updateResource?.Invoke(accountData.diamond, accountData.coin);
        ManagerAccount.Instance.UpdateAccount(accountData);
        SetChooseCarBTN();

    }

    public void SelectCar()
    {
        accountData.currentCarSkinID = currentSkin;
        accountData.currentCarID = currentIndex;
        ManagerAccount.Instance.UpdateAccount(accountData);
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.AreaScene);
    }


    public void SetEffectOn()
    {
        foreach(var par in this.effectUpdate)
        {
            par.Play();
        }
    }
    public void SetEffectOff()
    {
        foreach (var par in this.effectUpdate)
        {
            par.Stop();
        }
    }
}

