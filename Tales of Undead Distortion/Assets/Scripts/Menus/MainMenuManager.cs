using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject controlsMenu;
    public GameObject LoadingScreenMenu;

    public Slider LoadingBar;

    AsyncOperation async;

    public void LoadLevel(int LVL)
    {
        StartCoroutine(LoadingScreen());    
    }

    IEnumerator LoadingScreen()
    {
        LoadingScreenMenu.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            LoadingBar.value = async.progress;
            if (async.progress == 0.9f)
            {
                LoadingBar.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }

    }


    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void OpenControls()
    {
        controlsMenu.SetActive(true);
    }

    public void CloseControls()
    {
        controlsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
        
    }

    public void QuitGame()

    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }


}
