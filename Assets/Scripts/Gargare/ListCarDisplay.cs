
using System.Collections.Generic;

using UnityEngine;


public class ListCarDisplay: MonoBehaviour
{

    public static ListCarDisplay Instance;
    public List<GameObject> listCar;


    private GameObject currentDisplay; 

    private void Start()
    {
        Instance = this;
       

        listCar[0].SetActive(true);
        currentDisplay = listCar[0];
    }


    private void ResetPositionCar()
    {
        Vector3 pos = currentDisplay.transform.position;
        pos.y = 0;
        currentDisplay.transform.position = pos;
        currentDisplay.SetActive(false);
    }

    [ContextMenu("TEST")]
    public void SetDisplayCar(int IDcar, int IDskin)
    {
       
        GameObject carDisplay = null;

        foreach (GameObject go in listCar)
        {
            if(go.name == $"Car_{IDcar}{IDskin}")
            {
                carDisplay = go;
                break;
            }
        }
        ResetPositionCar();
        currentDisplay = carDisplay;
        currentDisplay.SetActive(true);
        

    }





}

