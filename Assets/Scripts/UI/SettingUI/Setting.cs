
using System;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


public  class Setting : MonoBehaviour
{
    [SerializeField] private ChangeValueSlider musicSlider;
    [SerializeField] private ChangeValueSlider sfxSlider;

    

    [SerializeField] private TMP_Dropdown graphicMenu;


    

    private int graphicValue = 0;

    [SerializeField] protected GameObject UI;


    private void OnEnable()
    {
        musicSlider.InstiateValue(ManagerSound.Instance.VolumeMusicBackgound);
        sfxSlider.InstiateValue(ManagerSound.Instance.VolumeCarSFX);


    }

    public void ChangeGraphicOption(int arg0)
    {
       
        graphicValue = arg0;
    }

    protected void ChangeSound()
    {

        Debug.Log(graphicValue);
        ManagerSound.Instance.ChangeVolumeMusicBackground(musicSlider.Value);
        ManagerSound.Instance.ChangeVolumeSFX(sfxSlider.Value);
        QualitySettings.SetQualityLevel(graphicValue);
        
    }
    protected virtual void CloseUI()
    {
        UI.SetActive(false);
    }
}
