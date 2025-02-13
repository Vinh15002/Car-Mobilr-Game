

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerGamePlay: MonoBehaviour
{

    public List<GameObject> allCar;

    public float currentTime = 3.2f;

    public void Start()
    {

        StartCoroutine(CoutDownTime());
        Time.timeScale = 0;
        SetUpData();
        
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
        Camera.main.gameObject.GetComponent<CameraFollower>().carTarget = car.transform;
        GetComponent<ManagerCar>().mainCar = car.transform.Find("Body").gameObject;
        ChangeTargetEvent.setTarGetCar?.Invoke(car);
    }

    private IEnumerator CoutDownTime()
    {

        while (currentTime > 0f)
        {
            currentTime -= (float)(Time.unscaledTime*0.01);
            yield return null;

            CountDownEvent.transferTime?.Invoke(currentTime);

        }
        Time.timeScale = 1;


        
    }


}

