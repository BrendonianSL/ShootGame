using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Releveant GameObjects")]
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject howtoplayScreen;

    private bool settingsActive;
    private bool creditsActive;
    private bool howtoplayActive;

    private void Awake()
    {
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        howtoplayScreen.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        creditsActive = !creditsActive; //Vice Versa Statement

        if(creditsActive)
        {
            creditsScreen.SetActive(true);
        } else
        {
            creditsScreen.SetActive(false);
        }

    }

    public void Settings()
    {
        settingsActive = !settingsActive;

        if(settingsActive)
        {
            settingsScreen.SetActive(true);
        } else
        {
            settingsScreen.SetActive(false);
        }
    }

    public void HowToPlay()
    {
        howtoplayActive = !howtoplayActive;

        if(howtoplayActive)
        {
            howtoplayScreen.SetActive(true);
        } else
        {
            howtoplayScreen.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
