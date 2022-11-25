using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
   [SerializeField] private float _movespeed;
   [SerializeField] private float _jumpForce;
   
   private bool _isGrounded = false;
   private SpriteRenderer _spriteHero;
   private Rigidbody2D _rigidbody2DHero;
   private Animator _animatorHero;
   
   private States State
   {
      get { return (States)_animatorHero.GetInteger("state"); }
      set {_animatorHero.SetInteger("state",(int)value);}
   }
   

   private void Awake()
   {
      _spriteHero = GetComponentInChildren<SpriteRenderer>(); 
      _rigidbody2DHero = GetComponent<Rigidbody2D>();
      _animatorHero = GetComponentInChildren<Animator>();
   }
   private void Update()
   {
      if (_isGrounded) State = States.idle;
      
      if (Input.GetButton("Horizontal"))
      {
         Run();
      }

      if (Input.GetButtonDown("Jump")&& _isGrounded)
      {
         Jump();
      } 
   }

   private void FixedUpdate()
   {
      CheckGround();
   }

   public void Run()
   {
      if (_isGrounded) State = States.run;
      Vector3 direction = transform.right * Input.GetAxis("Horizontal");
      transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _movespeed * Time.deltaTime);
      _spriteHero.flipX = direction.x < 0.0f;
   }
   public void Jump()
   {
      _rigidbody2DHero.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
   }

   private void CheckGround()
   {
      if (!_isGrounded) State = States.jump;
      Collider2D[] groundCollider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
      _isGrounded = groundCollider.Length > 1;
   }
}

public enum States
{
   idle,
   run,
   jump
}
