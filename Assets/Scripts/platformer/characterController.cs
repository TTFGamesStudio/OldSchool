using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Controller : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    [SerializeField] private Vector2 _input;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private characterSoundPlayer _soundPlayer;
    [SerializeField] private bool onGround;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance = 1f;
    [SerializeField] private Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _soundPlayer = GetComponent<characterSoundPlayer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();
        updateVelocity();
        _controller.Move(velocity);
        updateAnimations();
        characterFacing();
        groundCheck();
    }

    void updateInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _input = new Vector2(x,y);
    }

    void updateVelocity()
    {
        velocity.z = (moveSpeed * _input.x * Time.deltaTime) * -1f;
        velocity.y += Time.deltaTime * gravity;
        velocity.x = 0;
        jump();
    }

    void jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && onGround)
        {
            velocity.y = jumpForce;
            _soundPlayer.playJump();
        }
    }

    void characterFacing()
    {
        if(_input.x !=0)
        {
            if (_input.x < 0)
            {
                transform.localScale = new Vector3(1, 1, -1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    
    void updateAnimations()
    {
        if (_input.x > 0.1f || _input.x < -0.1f)
        {
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    }

    //check if the player is touching the ground
    void groundCheck()
    {
        if(Physics.Raycast(transform.position, -transform.up, groundCheckDistance,groundMask))
        {
            if(!onGround)
            {
                _soundPlayer.playImpact();
            }
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
}
