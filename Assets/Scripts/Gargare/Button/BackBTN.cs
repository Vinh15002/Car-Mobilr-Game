using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BackBTN : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.AreaScene);
    }
}

