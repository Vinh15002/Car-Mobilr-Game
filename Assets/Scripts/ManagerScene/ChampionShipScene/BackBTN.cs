using System;
using UnityEngine;
using UnityEngine.UI;

namespace ChampionShipScene
{
    public class BackBTN: MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(ChangeToMenuScene);
        }

        public void ChangeToMenuScene()
        {
            ManagerScene.Instance.ChangeSceneNoLoading(StringScene.MenuSelectScene);
        }
    }
}
