using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Build.Pipeline.Tasks;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Car car;
    DatabaseReference DBContext;

    private void Start()
    {
        DBContext = FirebaseDatabase.DefaultInstance.RootReference;
    }

    [ContextMenu("Test")]
    public void Updata()
    {
        string json = JsonUtility.ToJson(car);
        DBContext.Child("ItemCar").Push().SetValueAsync(json);
        Debug.Log("IsPushing");
    }
    
}

