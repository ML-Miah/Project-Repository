using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resDropDown;

    Resolution[] res;

    private void Start()
    {
        res = Screen.resolutions;

        resDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + "x" + res[i].height + " " + res[i].refreshRate.ToString();
            options.Add(option);

            if (res[i].width == Screen.width && res[i].height == Screen.height)
            {
                currentResIndex = i;
                
            }
        }

        resDropDown.AddOptions(options);
        resDropDown.value = currentResIndex;
        resDropDown.RefreshShownValue();
    }

    public void SetRes (int resIndex)
    {
        Resolution resolution = res[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("CHANGING RES");
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int QIndex)
    {
        QualitySettings.SetQualityLevel(QIndex);
        Debug.Log("CHANGING");
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Debug.Log("FULLSCREEN");
    }


}




