using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;
  
    
    // Start is called before the first frame update
    private void Start()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));

        if (PlayerPrefs.HasKey("Quality"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("Quality");
        }

        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);

        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetQuality(int qIndex) 
    {
        QualitySettings.SetQualityLevel(qIndex);

        PlayerPrefs.SetInt("Quality", qIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
