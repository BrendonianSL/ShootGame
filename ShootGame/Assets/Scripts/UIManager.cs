using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Game Objects")]
    [Tooltip("Place Our Game Over Screen Here")][SerializeField] private GameObject gameoverScreen; //Holds Our GameOver Screen Object
    [Tooltip("Place Our Pause Screen Here")][SerializeField] public GameObject pauseScreen; //Holds Our Pause Screen Object
    [Tooltip("Holds Our Score Text")][SerializeField] private TextMeshProUGUI scoreText; //Holds Our Score Text
    [Tooltip("Holds Our Timer Text")][SerializeField] private TextMeshProUGUI timeText; //Holds Our Score Text

    [SerializeField] private TextMeshProUGUI gunName;

    [SerializeField] private TextMeshProUGUI ammoCount;

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

    public void ChangeScore(int scoreAmount)
    {
        scoreText.text = "score: " + scoreAmount;
    }

    public void ChangeTime(int currentTime)
    {
        timeText.text = "time " + currentTime;
    }
}
