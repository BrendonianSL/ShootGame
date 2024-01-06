using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float currentTime { get; private set; } //Holds The Current Time. Serailzied So We Can See It In Inspector

    [Header("Variables")]
    [SerializeField] private float maxTime; //Holds The Maximum Amount Of Time Available. Serailzied So We Can See It In Inspector
    public bool isPaused { get; private set; } //This Variable Is READ ONLY To Other Scripts. Meaning Other Scripts Can Only Check What This Value Is Set To, Not Change It Themselves.
    [HideInInspector] public int score; //This Variable Holds Our Score "HideInInspector" Makes It Unavaiable For Us To Manipulate Inside The Unity Engine

    [Header("Script References")]
    [SerializeField] private UIManager uiManager; //This Is Unique Because This Holds Direct Reference To Something We Created. Ask Me About This If Needed. Private So We Don't Reference It From Other Scripts

    private void Awake() //Gets Called BEFORE Game Start
    {
        currentTime = maxTime; //Sets Current Time Equal To Maximum Time
        Cursor.visible = false; //Hides Cursor
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= Time.deltaTime; //Decreases Time For Every Second Passing
        int seconds = Mathf.FloorToInt(currentTime);
        uiManager.ChangeTime(seconds);

        if(currentTime <= 0) //If Current Time Is Equal Or Below Specified Value
        {
            GameOver(); //Call Game Over
        }
    }

    public void IncreaseScore(int scoreAmount) //Public Function Responsible For Increasing Score. This Function REQUIRES A Integer To Be Given In Order To Run
    {
        score += scoreAmount; //Increases Score By Amount Passed In
        uiManager.ChangeScore(score);
    }

    public void DecreaseScore(int scoreAmount) //Public Function Responsible For Decreasing Score. This Function REQUIRES A Integer To Be Given In Order To Run
    {
        score -= scoreAmount; //Increases Score By Amount Passed In
        uiManager.ChangeScore(scoreAmount);
    }


    public void IncreaseTime(float timeAmount) //Public Function Responsible For Increasing Time. This Function REQUIRES A Float To Be Given In Order To Run
    {
        currentTime += timeAmount; //Increases Time Based Off Value
    }

    public void DecreaseTime(float timeAmount) //Public Function Responsible For Decreasing Time. This Function REQUIRES A Float To Be Given In Order To Run
    {
        currentTime -= timeAmount; //Decreases Time Based Off Value
    }

    public void PauseGame()
    {
        isPaused = !isPaused; //This is a vice versa statement. All this means is that it sets the isPaused value to the opposite of what it currently is
        if(isPaused)
        {
            Time.timeScale = 0f;
            uiManager.pauseScreen.SetActive(true);
            Cursor.visible = true; //Reveals Cursor
            Cursor.lockState = CursorLockMode.None; //Unlocks the Cursor
            //Reveal Cursor & Stop Accepting Player Input
        } else
        {
            Time.timeScale = 1f;
            uiManager.pauseScreen.SetActive(false);
            Cursor.visible = false; //Hides Cursor 
            Cursor.lockState = CursorLockMode.Locked; //Relocks Cursor
            //Hide Cursor & Start Accepting Input
        }

    }
    
    private void GameOver() //Private Function Responsible For Ending The Game
    {
        Time.timeScale = 0f; //Freezes Game Time
        uiManager.EndScreen();
        Debug.Log("Game Is Over"); //Debugging...
    }
}
