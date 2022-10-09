/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: September 27 2022
/// FILE: Player_Movement.cs
/// player movement class
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //these will be our base player movement speed and jump height. 
    //serialized field lets us have private variables vieded and edited in Unity editor 
    [SerializeField] private float _playerMovementSpeed = 5.0f; 
    // [SerializeField] private float _playerJumpHeight = 5.0f;  
    private Vector2 _moveDirection; 
    public Camera camera; 
    private Vector2 _mousePosition; 

    [SerializeField] private Collider2D _playerCollider;  

    // for animation
    //public Animator animator;


    //player rigidbody
    [SerializeField] private Rigidbody2D _playerRB; 

    // Start is called before the first frame update
    private void Start()
    {
        //grab the RigidBody2D component for movement
        _playerRB = GetComponent<Rigidbody2D>(); 
        _playerCollider = GetComponent<Collider2D>(); 


        //null game object check
        if(_playerRB == null)
        {
            Debug.Log("Player is Missing RigidBody2D");
        }
    }

    // Update is called once per frame
    //great for processing inputs
    private void Update()
    {
        //processing player user inputs
        ProcessInputs(); 
    }

    //fixed update is called every fixed framerate. 
    //better for physics calculations. 
    private void FixedUpdate()
    {
        //get input and move player
        MovePlayer(); 
    }


    private void ProcessInputs()
    {
        //using the unity input manager
        //grab the horizontal axis input. 
        //grab the vertical axis input. 
        //this will be the left and right arrows on a keyboard or a and d
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY).normalized;

        _mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    //player movement function 
    private void MovePlayer()
    {
        //move the player
        _playerRB.velocity = new Vector2(_moveDirection.x * _playerMovementSpeed, _moveDirection.y * _playerMovementSpeed); 

        //mouse look
        Vector2 lookDirection = _mousePosition - _playerRB.position; 

        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        _playerRB.rotation = lookAngle; 

        // animation
        //animator.SetFloat("speed", Mathf.Abs(_playerRB.velocity.x));
    }

    //for testing
    // public void OnCollisionEnter2D(Collision2D col)
    // {
    //     Debug.Log("OnCollisionEnter2D");
    //     Debug.Log("collide (name) : " + col.collider.gameObject.name);
    // }
}