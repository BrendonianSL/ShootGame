using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Variables")]
    [Tooltip("Determines The Speed At Which We Are Able To Move")]
    public float moveSpeed; //Controls How Fast Our Player Moves
    [Tooltip("Determines Our Jump Height")]
    public float jumpForce; //Controls How Much We Can Jump
    [Tooltip("Gotta Figure This Out")]
    public float airMultiplier; //Controls Multiplicative Air Movement

    [Tooltip("Determines The Direction Our Player Is Facing")]
    [SerializeField]private Transform orientation; //Controls The Orientation Of Our Player
    
    [Header("Drag Variables")]
    [Tooltip("Controls How Much Drag We Have While Grounded")]
    [SerializeField] private float groundDrag; //Controls Ground Drag
    [Tooltip("Controls How Much Drag We Have While In The Air")]
    [SerializeField] private float airDrag; //Controls Air Drag


    [HideInInspector] public bool isGrounded { get; private set; } //Controls If We Are Grounded
    [Header("Grounded Variables")]
    [Tooltip("What Is Currently Our Ground Layer?")]
    [SerializeField] private LayerMask groundLayer; //Holds What Is The Ground Layer
    public float playerHeight; //How Tall Is Our Player
    
    private PlayerInput playerInput;
    private Vector3 m_moveDirection; //Controls The Direction We Are Currently Moving
    private Rigidbody rb; //Holds Our Rigidbody

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //Grabs Our Rigidbody And Sets It To It's Variable
        playerInput = GetComponent<PlayerInput>(); //Grabs Our PlayerInput Script
        rb.freezeRotation = true; //Freeze It's Rotation
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer); 
        playerInput.MovementInput(); //Constantly Grabbing Player Input
        SpeedControl(); //Constantly Controls Velocity

        if(isGrounded) //If We Are Grounded
        {
            rb.drag = groundDrag; //Our Drag Is Now Equal To Our GroundDrag Variable
        } else if (!isGrounded) //If Not We Check For If We Aren't
        {
            rb.drag = airDrag; //Our Drag Is Now Equal To Our AirDrag Variable
        }
    }

    private void FixedUpdate() //Called At The Same Rate Of Our Physics Engine
    {
        MovePlayer();
    }

    private void MovePlayer() //Function That Controls Player Movement
    {
        m_moveDirection = orientation.forward * playerInput.m_verticalInput + orientation.right * playerInput.m_horizontalInput; //Sets Our MoveDirection To Our Forward + Right Variable To Also Include Diagnol Movement

        if(isGrounded)
        {
            rb.AddForce(m_moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); //Adds Force To The Direction We Are Moving
        } else if(!isGrounded)
        {
            rb.AddForce(m_moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force); //Adds Force To The Direction We Are Moving
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); //Applies A Short Non Continued Burst
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limit Velocity If We Need To
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, rb.velocity.z);
        }
    }
}
