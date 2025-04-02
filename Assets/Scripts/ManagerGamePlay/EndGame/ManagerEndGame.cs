


using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagerEndGame : MonoBehaviour
{

    public GameObject positonRank;
    public GameObject rankCar;
    public GameObject UI;

    public TMP_Text text_add;
    public static ManagerEndGame Instance;

    public List<GameObject> UIEndGameOff;

    private int currentPos = 0;

    private List<FinishData> nameCar;

    public Button back;




    private void Start()
    {
        Instance = this;
        nameCar = new List<FinishData>();
        back.onClick.AddListener(BackScene);
    }

    private void BackScene()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.AreaScene);
    }

    public void AddCarRank(bool isMainCar)
    {
        if(!isMainCar) {

            AddCarAIComplete();
        }
        else
        {
            UI.SetActive(true);
            foreach(var item in UIEndGameOff)
            {
                item.SetActive(false);
            }
            AddMainCarComplete();
            AddCoin();

            while (currentPos < ManagerCar.Instance.GetAmountCar())
            {
                currentPos++;
                AddCarUnComplete();
                
            }
            AddUI();
        }

       
        
        
    }

    //1 - > 300 _400 
    //2, 3 -> 100 - 300
    //4, -> 0-100
    private void AddCoin()
    {
        int random = Random.Range(0, 100);
        int valueAdd = (4 - currentPos) * 100 + random;
        text_add.text = valueAdd.ToString();
        ManagerAccount.Instance.AddCoint(valueAdd);
    }

    private void AddUI()
    {
        foreach(var item in nameCar)
        {
            AddPositionCar(item);
        }
    }

    private void AddCarAIComplete()
    {
        currentPos++;
        string name = RandomName.GetRandomName();
        FinishData data = new FinishData(currentPos.ToString(), name, TimeGamePlay.Instance.ConvertTime());
        nameCar.Add(data);
    }

    private void AddCarUnComplete()
    {
        
        string name = RandomName.GetRandomName();
        FinishData data = new FinishData(currentPos.ToString(), name, "...");
        nameCar.Add(data);
    }
    private void AddMainCarComplete()
    {
        currentPos++;
        string name;
        name = "YOU";
        if (ManagerAccount.Instance != null)
        {
            name = ManagerAccount.Instance.MainAccout.name;
        }
        
        FinishData data = new FinishData(currentPos.ToString(), name, TimeGamePlay.Instance.ConvertTime());
        nameCar.Add(data);
    }
   
    public void AddPositionCar(FinishData data)
    {
      
        string pos = data.pos + "ST";
        string time = data.time;
        string name = data.name;
        
        GameObject game = Instantiate(positonRank, rankCar.transform);
        game.GetComponent<Position>().SetContent(pos, name, time);
    }






}

