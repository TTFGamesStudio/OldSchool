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
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            velocity.y = jumpForce;
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
}
