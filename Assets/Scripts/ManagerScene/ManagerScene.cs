


using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class ManagerScene : MonoBehaviour
{
    public static ManagerScene Instance;

    public GameObject loadingCanvas;

  



    private void Start()
    {
        Instance = this;
        
        DontDestroyOnLoad(this);
    }

    public void ChangeSceneNoLoading(string name)
    {
        
        SceneManager.LoadScene(name,  LoadSceneMode.Single);
        
        
    }

    public void ChangeSceneLoading(string name)
    {


        LoadSceneAsync(name);
    }


    public async void  LoadSceneAsync(string name)
    {
        
      
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        loadingCanvas.SetActive(true);
        LoadingEvent.changeTextLoading?.Invoke(0);
        
        operation.allowSceneActivation = false;
        float process = 0;
        do
        {
            await Task.Delay(100);
            process = Mathf.Clamp01(operation.progress/0.9f);
            
            LoadingEvent.changeTextLoading?.Invoke(process);
        }while(operation.progress < 0.9f);
        
        await Task.Delay(1000);
        operation.allowSceneActivation = true;
        await Task.Delay(1000);
        loadingCanvas.SetActive(false);
        

    }
}

