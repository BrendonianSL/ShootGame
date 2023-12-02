using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float m_horizontalInput; //Responsible For Input On Our Horizontal
    [HideInInspector] public float m_verticalInput; //Responsible For Input On Our Vertical
    private float m_xRotation; //Variable Responsible For Camera Rotation Along The X-Axis. This Controls Up & Down
    private float m_yRotation; //Variable Responsible For Camera Rotation Along The Y-Axis. This Controls Left & Right
    
    [Header("Sensitivities")]
    [Tooltip("Controls X Sensitivity")] public float sensX; //Controls X Sensitivity
    [Tooltip("Controls Y Sensitivity")] public float sensY; //Controls Y Sensitivity
    [Tooltip("Holds The Transform That Tracks Our Player's Orientation")] public Transform orientation; //Tracks The Orientation Of Our Player

    [Header("Script References")]
    [Tooltip("Holds PlayerMovement Script")] public PlayerMovement playerMovement;
    //[Tooltip("Holds Camera Script")] private PlayerCamera playerCamera;
    //[Tooltip("Holds Weapons Manager")][SerializeField] private WeaponsManager weaponsManager;
    [Tooltip("Holds GameMaster Reference")][SerializeField] private GameManager gameManager;

    [Header("Other Information")]
    [Tooltip("Determines If We Are Accepting Automatic Input")] public bool automaticInput;
    [Tooltip("Holds Player Camera")][SerializeField] private Camera camera;

    private void Awake()
    {
        //playerCamera = camera.GetComponent<PlayerCamera>();
    }

    private void Update()
    {
        KeyboardInput();
    }

    public void MovementInput()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal"); //Sets Our Raw Horizontal Input To A Variable We Can Manipualte
        m_verticalInput = Input.GetAxisRaw("Vertical"); //Sets Our Raw Vertical Input To A Variable We Can Manipulate

        if(Input.GetButtonDown("Jump"))
        {
            //playerMovement.Jump();
        }
    }

    private void KeyboardInput()
    {
        if(automaticInput)
        {
            if(Input.GetButton("Shoot"))
            {
            }
        } else
        {
            if(Input.GetButtonDown("Shoot"))
            {
            }
        }

        if(Input.GetButtonDown("Reload")) //Accepts Reloading Button Press
        {
            
        }

        if(Input.GetButtonDown("Pause"))
        {
            gameManager.PauseGame();
        }
    }

    public void CameraInput() //Controls Camera Movement
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX; //Gets Mouse Input From X Axis
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY; //Gets Mouse Input From Y Axis

        m_yRotation += mouseX; //Sets The Variable Equal To MouseX Variable. This Is Because MouseX Rotates On The Y-Axis
        m_xRotation -= mouseY; //Sets The Variable Equal To Our MouseY Variable. This Is Because MouseY Rotates On X-Axis.
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f); //Limits The Value This Can Return Because We Don't Want The Camera Overrotating.

        camera.transform.rotation = Quaternion.Euler(m_xRotation, m_yRotation, 0); //Rotates The Camera Evenly With The Mouse
        orientation.rotation = Quaternion.Euler(0, m_yRotation, 0); //Rotates The Oritentation Variable With The Y Because We Don't Want To Randomly Start Flying        
    }

    public void ObjectInteract()
    {

    }
}
