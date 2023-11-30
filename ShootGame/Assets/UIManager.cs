using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject GameOverScreen;

    private void Start ()
    {
        GameOverScreen.SetActive(false);
    }

    public void EndScreen ()
    {
        GameOverScreen.SetActive(true);
    }
}
