
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

