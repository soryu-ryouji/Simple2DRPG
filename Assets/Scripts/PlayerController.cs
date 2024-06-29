using System;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

namespace Simple2DRPG
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigid;

        private float _jumpForce = 5;
        private float _moveSpeed = 6;
        private float _horizontalInput;

        public int FacingDirection { get; private set; } = 1;

        private void Awake()
        {
            _animator = this.transform.GetComponentInChildren<Animator>();
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            CheckInput();
            CheckAnim();
        }

        public void Move()
        {
            _rigid.velocity = new Vector2(_horizontalInput * _moveSpeed, _rigid.velocity.y);
        }

        public void Jump()
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        }

        private void CheckInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        private void CheckAnim()
        {
            CheckFlip();
            _animator.SetBool("IsMoving", _horizontalInput != 0);
        }

        private void Flip()
        {
            FacingDirection *= -1;

            transform.Rotate(0, 180, 0);
        }

        private void CheckFlip()
        {
            if (_horizontalInput > 0 && FacingDirection != 1) Flip();
            else if (_horizontalInput < 0 && FacingDirection != -1) Flip();
        }
    }
}
