using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Object References")]
    [SerializeField] private AudioMixer audioMixer; //Holds Audio Mixer
    [SerializeField] private Slider xSlider, ySlider;

    private void Start()
    {
        xSlider.value = playerInput.sensX; //Sets Slider Value To Max Value
        ySlider.value = playerInput.sensY; //Sets Slider Value To Max Value
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetSensitivityX(float xValue)
    {
        playerInput.sensX = xValue;
    }

    public void SetSensitivityY(float yValue)
    {
        playerInput.sensY = yValue;
    }
}
