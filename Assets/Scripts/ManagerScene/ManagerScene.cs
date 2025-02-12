


using System.Collections;
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
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }

    public void ChangeSceneLoading(string name) {

        loadingCanvas.SetActive(true);
        StartCoroutine(LoadSceneAsync(name));
    }


    public IEnumerator LoadSceneAsync(string name)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

        while (!operation.isDone)
        {
            float progress = operation.progress;
            yield return null;

            LoadingEvent.changeTextLoading?.Invoke(progress);


        }
        loadingCanvas.SetActive(false);


    }
}

