using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    private bool pauseActive;
    private bool gameoverActive;
    private bool settingsActive;

    private GameObject lastActiveScreen;

    [Header("Game Objects")]
    [Tooltip("Place Our Game Over Screen Here")][SerializeField] private GameObject gameoverScreen; //Holds Our GameOver Screen Object
    [Tooltip("Place Our Pause Screen Here")][SerializeField] public GameObject pauseScreen; //Holds Our Pause Screen Object
    [Tooltip("Place Our Settings Screen Here")][SerializeField] private GameObject settingsScreen; 
    [Tooltip("Holds Our Score Text")][SerializeField] private TextMeshProUGUI scoreText; //Holds Our Score Text
    [Tooltip("Holds Our Timer Text")][SerializeField] private TextMeshProUGUI timeText; //Holds Our Score Text

    [SerializeField] private TextMeshProUGUI gunName;
    [SerializeField] private TextMeshProUGUI ammoCount;

    [Header("Script References")]
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameoverScreen.SetActive(false); //Sets The Game Over Screen To False On Start
        pauseScreen.SetActive(false); //Sets The Pause Screen To False On Start
    }

    private void Update()
    {
    }

    public void EndScreen() //Gets Called By Game Manager
    {
        gameoverScreen.SetActive(true); //Activates The Game Over Screen
    }

    public void ChangeScore(int scoreAmount) //Manipulates Score Based On Given Value
    {
        scoreText.text = "score: " + scoreAmount;
    }

    public void ChangeTime(int currentTime) //Manipulates Time Based On Given Value
    {
        timeText.text = "time " + currentTime;
    }

    public void PauseScreen()
    {
        pauseActive = !pauseActive;

        if(pauseActive)
        {
            pauseScreen.SetActive(true);
        } else
        {
            pauseScreen.SetActive(false);
        }
    }

    public void SettingsScreen()
    {
        //Deactivate Last Screen
        //Set Value To False
        //Set Value to Flase
        settingsActive = !settingsActive;

        if(settingsActive)
        {
            settingsScreen.SetActive(true);
        } else 
        {
            settingsScreen.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
