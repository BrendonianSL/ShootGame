using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Time Variables")]
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime;

    private void Awake()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= Time.deltaTime; //Decreases Time For Every Second Passing
        Debug.Log(currentTime);

        if(currentTime <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Is Over");
    }
}