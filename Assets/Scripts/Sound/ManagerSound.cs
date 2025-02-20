using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public  class ManagerSound : MonoBehaviour
{
    public static ManagerSound Instance;

    public float VolumeCarSFX => volumeCarSFX;
    public float VolumeMusicBackgound => volumeMusicBackground;





    public float speedSoundDriftCar = 1.0f;


    private Transform SFX;
    private Transform MusicBackground;

    public AudioSource soundSpeedCar;
    public AudioSource soundDriftCar;


    private float volumeCarSFX = 1f;
    private float volumeMusicBackground = 1f;

    private float currentVolumeDrift = 0f;

    private void Start()
    {
        DontDestroyOnLoad(this);
        SFX = transform.Find("SFX");
        MusicBackground = transform.Find(EnumSound.MusicBG.ToString());
        soundSpeedCar = SFX.Find(EnumSound.SpeedUp.ToString()).GetComponent<AudioSource>();
        soundDriftCar = SFX.Find(EnumSound.Drift.ToString()).GetComponent<AudioSource>();
        Instance = this;
        


    }


    public void ChangeVolumeMusicBackground(float value)
    {
        MusicBackground.GetComponent<AudioSource>().volume = value;
        volumeMusicBackground = value;


    }

    public void ChangeVolumeSFX(float value)
    {
        volumeCarSFX = value;

    }


    public void AddSoundCar(float speedCar)
    {
        if(speedCar <= 5)
        {
            soundSpeedCar.volume = 0f;
        }
        else if (speedCar <= 20)
        {
            soundSpeedCar.volume = 0.3f * (speedCar /30) * volumeCarSFX;
        }
        else if (speedCar <= 50)
        {
            soundSpeedCar.volume = speedCar / 60 * volumeCarSFX;
        }
        else
        {
            soundSpeedCar.volume =1f * volumeCarSFX;
        }

        
    }





    public void TurnOnDrift()
    {
        float value = Mathf.Lerp(currentVolumeDrift, 1, 1f * speedSoundDriftCar);
        soundDriftCar.volume = value * volumeCarSFX;

    }

    public void TurnOffDrift()
    {
        float value = Mathf.Lerp(currentVolumeDrift, 0, 3f * speedSoundDriftCar);
        soundDriftCar.volume = value * volumeCarSFX;
    }




}

