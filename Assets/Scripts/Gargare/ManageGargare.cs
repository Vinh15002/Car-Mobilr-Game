using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class ManageGargare: MonoBehaviour
{


    public static ManageGargare Instance;
    [SerializeField] private Button LeftBTN;
    [SerializeField] private Button RightBTN;

    private int currentIndex = 0;
    private int currentSkin = 0;

    private List<Car> dataCar;

    DatabaseReference DBContext;






    private void Start()
    {
        Instance = this;
        DBContext = FirebaseDatabase.DefaultInstance.RootReference;
        dataCar = new List<Car>();
        GetData();
        LeftBTN.onClick.AddListener(OnLeftClick);
        RightBTN.onClick.AddListener(OnRightClick);
        
    }

    
    private void GetData()
    {

        DBContext.Child("ItemCar").ChildAdded += AddDataCar; // Assuming GetValueAsync returns a Task<DataSnapshot>


    }

    private void AddDataCar(object sender, ChildChangedEventArgs e)
    {

        var snapshot = e.Snapshot;
        
        Car cardata = JsonUtility.FromJson<Car>(snapshot.Value.ToString());
        dataCar.Add(cardata);
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
        ManagerColor.Intance.SetUpColor(dataCar[currentIndex].skinCars);
    }


    public void setSkin(int index)
    {
        currentSkin = index;
        SetcurrentCar();

    }






}

