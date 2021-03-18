using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIMenuManager : MonoBehaviour
{
    static public bool paused = false;

    [Header ("Menus")]
    
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
  //  public GameObject collectablesMenu;
    public GameObject InventoryMenu;
    public GameObject LockedUI;

    public GameObject StartUI;
    public GameObject EndGameUI;


    
  

    public void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        LockedUI.SetActive(false);

        EndGameUI.SetActive(false);

        StartUI.SetActive(true);

        Time.timeScale = 0f;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (paused)
            {
                resumeGame();
            }

            else
            {
                pausegame();
            }
        }

        

      


    }

    public void pausegame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void resumeGame()
    {
        StartUI.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        resumeGame();
    }

    public void LockedOpen()
    {
        LockedUI.SetActive(true);
    }

    public void OpenInventory()
    {
        LockedUI.SetActive(false);
        InventoryMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseInventory()
    {
        LockedUI.SetActive(false);
        InventoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        EndGameUI.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;

    }




}
