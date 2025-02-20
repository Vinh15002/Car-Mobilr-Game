

using Assets.Scripts.Car;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerGamePlay: MonoBehaviour
{

    public List<GameObject> allCar;

    public float currentTime = 5.2f;

    public void Start()
    {

        
        Time.timeScale = 0;
        SetUpData();
        StartCoroutine(CoutDownTime());

    }

    private void SetUpData()
    {
        int currentCar = 0;
        int currentSkin = 0;

        if(ManagerAccount.Instance != null)
        {
            currentCar = ManagerAccount.Instance.MainAccout.currentCarID;
            currentSkin = ManagerAccount.Instance.MainAccout.currentCarSkinID;
            
        }

        GameObject car = null;
        foreach(var item in allCar)
        {
            if (item.name == $"Car_{currentCar}{currentSkin}")
            {
                car = item;
                break;
            }
        }
        car.SetActive(true);
        if (ManagerAccount.Instance != null)
        {
            car.GetComponent<CarController>().maximunMotoTorque = ManagerAccount.Instance.getSpeedCurrentCar();
            car.GetComponentInChildren<BuffSpeed>().SetBuffSpeed(ManagerAccount.Instance.getPowerCurrentCar());

        }
        else
        {
            car.GetComponent<CarController>().maximunMotoTorque = 900;
            car.GetComponentInChildren<BuffSpeed>().SetBuffSpeed(20f);
        }


        Camera.main.gameObject.GetComponent<CameraFollower>().carTarget = car.transform;
        Camera.main.gameObject.GetComponent<CameraFollower>().FollowTarget();
        GetComponent<ManagerCar>().mainCar = car.transform.Find("Body").gameObject;

        ChangeTargetEvent.setTarGetCar?.Invoke(car);
    }

    private IEnumerator CoutDownTime()
    {

        while (currentTime > 0f)
        {
            currentTime -= 0.01f;


            if (currentTime < 3.2f)
            {
                CountDownEvent.transferTime?.Invoke(currentTime);
            }
            yield return new WaitForSecondsRealtime(0.01f);


        }
        Time.timeScale = 1;


        
    }


}

