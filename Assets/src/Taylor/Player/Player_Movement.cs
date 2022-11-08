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

public sealed class Player_Movement : MonoBehaviour
{
    private Player_Movement() {}

    public static Player_Movement Instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() {}
        internal static readonly Player_Movement instance = new Player_Movement();
    }
    //these will be our base player movement speed and jump height. 
    //serialized field lets us have private variables vieded and edited in Unity editor 
    [SerializeField] private Damageable damageable; 
    [SerializeField] private float _playerMovementSpeed = 5.0f; 
    [SerializeField] float activeMoveSpeed; 
    [SerializeField] private float _playerDashSpeed;
    [SerializeField] private float _playerDashCounter;
    [SerializeField] private float _playerDashCooldownCounter;
    [SerializeField] private float _playerDashCooldown = 1f; 


    [SerializeField] private float _playerDashLength= 0.5f; 
 
    private Vector2 _moveDirection; 
    public Camera camera;
    private Vector2 _mousePosition; 

    [SerializeField] private Collider2D _playerCollider;  

    // for animation
    //public Animator animator;


    //player rigidbody
    [SerializeField] private Rigidbody2D _playerRB; 

    [SerializeField] private GameObject weapon;

    // Start is called before the first frame update
    private void Start()
    {
        //grab the RigidBody2D component for movement
        _playerRB = GetComponent<Rigidbody2D>(); 
        _playerCollider = GetComponent<Collider2D>(); 
        camera = Camera.main;
        activeMoveSpeed = _playerMovementSpeed; 

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

        if(Input.GetButtonDown("Fire1"))
        {
            weapon.GetComponent<Base_Weapon>().Fire();
            /* Plays Audio clip for gun firing on player clicks.
            NOTE: This feature will need to be adjusted for other weapon types later in develoment
            as they will have alternate sound bites.*/
            
            // This line currently causing a compiler error
            // FindObjectOfType<AudioManager>().Play("Pew");
        }

        HandlePlayerDash(); 
    }

    //player movement function 
    private void MovePlayer()
    {
        //move the player
        _playerRB.velocity = new Vector2(_moveDirection.x * activeMoveSpeed, _moveDirection.y * activeMoveSpeed); 

        //mouse look
        Vector2 lookDirection = _mousePosition - _playerRB.position; 

        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        _playerRB.rotation = lookAngle; 

        // animation
        //animator.SetFloat("speed", Mathf.Abs(_playerRB.velocity.x));
    }

    public void HandlePlayerDash()
    {

        //transform.position += _moveDirection * dashDistance; 

        //_playerRB = new Vector2(_moveDirection.x * dashDistance, _moveDirection.y * dashDistance); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_playerDashCooldownCounter <= 0 && _playerDashCounter <= 0)
            {
                activeMoveSpeed = _playerDashSpeed; 
                _playerDashCounter = _playerDashLength;
                damageable.enabled = false; 

            }
        }

        if(_playerDashCounter > 0)
        {
            _playerDashCounter -= Time.deltaTime;

            if(_playerDashCounter <= 0)
            {
                activeMoveSpeed = _playerMovementSpeed; 
                _playerDashCooldownCounter = _playerDashCooldown;
                damageable.enabled = true; 
            }
        }

        if(_playerDashCooldownCounter > 0)
        {
            _playerDashCooldownCounter -= Time.deltaTime;
        }
    }

    //for testing
    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        Debug.Log("collide (name) : " + col.collider.gameObject.name);

        // switch active weapon
        if(col.gameObject.tag == "Weapon")
        {
            weapon = col.gameObject.GetComponent<Base_Weapon>().SwitchActiveWeapon(weapon);
        }
        
        if(col.gameObject.tag == "weapon_upgrade")
        {
            weapon = col.gameObject.GetComponent<weapon_upgrade>().applyUpgrade(weapon);
        }
    }
}