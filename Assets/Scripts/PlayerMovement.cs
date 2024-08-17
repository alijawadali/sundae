using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set In Inspector")]
    public float speed = 10f;
    public float jumpPower = 10;

    [Header("Set Dynamically")]
    public bool isRunning;

    private Rigidbody2D _rigidbody2D;
    private Animator _anim;
    SpriteRenderer flip;

    private Vector3 _defaultScale;

   // private float _horizontalAxis = 0f;
    public bool _inGround;
    public Transform groundCHeck;
    public LayerMask groundlayer;

    bool right, left;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        _defaultScale = transform.localScale;
        right = false;
        left = false;
            
    }

    private void Update()
    {
        
        float playermove = Input.GetAxisRaw("Horizontal");
       // isRunning = _inGround && playermove != 0;
        if (playermove != 0)
        {
            MoveHA(playermove);
           

            // isRunning = _inGround  ;

        }
        else
        {
            stopmove();

        }
        

        if (left)
        {
            MoveHA(-speed);
            

        }
        if (right)
        {
            MoveHA(speed);
        }
    }

    private void FixedUpdate()
    {


       
       

        _inGround = Physics2D.OverlapCircle(groundCHeck.position,0.2f,groundlayer);
    }

   

    public void MoveHA(float playermove)
    {
        isRunning = true;
        _anim.SetBool("IsRunning", true);

        _rigidbody2D.velocity = new Vector2(playermove * speed, _rigidbody2D.velocity.y);

        if (playermove < 0)
        {
            flip.flipX = true;
        }
        else
        {
            flip.flipX = false;
        }
    }

    public void JumpButton()
    {

        if (_inGround)
        {
            _rigidbody2D.velocity = Vector2.up * jumpPower;
        }
    }

     public void stopmove()
    {
        isRunning = false;
        _anim.SetBool("IsRunning", false);

        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

    }

    public void leftmov()
    {
        left = true;
    }

    public void rightmov()
    {
        right = true;
    }

    public void mobilStop()
    {
        left = false;
        right = false;
        stopmove();
    }
     


}
