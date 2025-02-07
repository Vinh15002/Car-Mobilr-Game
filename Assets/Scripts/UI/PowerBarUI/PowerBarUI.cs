
using Assets.Scripts.Event;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.PowerBarUI
{
    public class PowerBarUI : MonoBehaviour
    {

        [SerializeField] private RawImage barImage;
        [SerializeField] private RectTransform edge;
        private RectTransform maskImage;
        private float barMaskWidth;

        private void Start()
        {
            maskImage = transform.Find("Maskbar").GetComponent<RectTransform>();
            barMaskWidth = maskImage.sizeDelta.x;
            ChangePowerUI(0);
        }

        private void OnEnable()
        {
            PowerCarEvent.getPresentPower += ChangePowerUI;
        }

        private void OnDisable()
        {
            PowerCarEvent.getPresentPower -= ChangePowerUI;
        }


        private void Update()
        {
            AnimationPowerUI();
        }
        private void ChangePowerUI(float present)
        {
            Vector2 barMaskSizeDelta = maskImage.sizeDelta;
            barMaskSizeDelta.x = present* barMaskWidth;
            maskImage.sizeDelta = barMaskSizeDelta;
            edge.anchoredPosition = new Vector2(barMaskSizeDelta.x, 0);
            edge.transform.gameObject.SetActive(present < 1);
        }

      

        private void AnimationPowerUI()
        {
            Rect uvRect = barImage.uvRect;
            uvRect.x += 0.2f*Time.deltaTime;
            barImage.uvRect = uvRect;
        }
    }
}
