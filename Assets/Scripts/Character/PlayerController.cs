using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerController : Character
    {
        [Header("Move info")]
        [SerializeField] private float _jumpForce = 15;
        [SerializeField] private float _moveSpeed = 6;
        [SerializeField] private float _horizontalInput;

        [SerializeField] private float _dashSpeed = 20;
        [SerializeField] private float _dashDuration = 0.3f;
        [SerializeField] private float _dashTime = 0;

        [SerializeField] private float _dashCooldown = 1;
        [SerializeField] private float _dashCooldownTimer;

        [Header("Attack info")]
        [SerializeField] private int _comboCounter;
        [SerializeField] private float _comboTime = 1;
        private bool _isAttacking;
        private float _comboTimeWindow;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            Move();
            CheckInput();

            _dashTime -= Time.deltaTime;
            _dashCooldownTimer -= Time.deltaTime;
            _comboTimeWindow -= Time.deltaTime;

            CheckAnim();
        }

        private void Dash()
        {
            if (_dashCooldownTimer < 0 && !_isAttacking)
            {
                _dashCooldownTimer = _dashCooldown;
                _dashTime = _dashDuration;
            }
        }

        public void Move()
        {
            if (_isAttacking) _rigid.velocity = new Vector2(0, 0);
            else if (_dashTime > 0) _rigid.velocity = new Vector2(FacingDirection * _dashSpeed, 0);
            else _rigid.velocity = new Vector2(_horizontalInput * _moveSpeed, _rigid.velocity.y);
        }

        public void Jump()
        {
            if (_isGrounded) _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        }

        private void CheckInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space)) Jump();
            if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();

            if (Input.GetKeyDown(KeyCode.J)) Attack();
        }

        private void Attack()
        {
            if (!_isGrounded) return;

            if (_comboTimeWindow < 0) _comboCounter = 0;
            _isAttacking = true;
            _comboTimeWindow = _comboTime;
        }

        public void AttackOver()
        {
            _isAttacking = false;
            _comboCounter++;
            if (_comboCounter > 2) _comboCounter = 0;
        }

        private void CheckAnim()
        {
            CheckFlip();
            _anim.SetFloat("YVelocity", _rigid.velocity.y);
            _anim.SetBool("IsMoving", _horizontalInput != 0);
            _anim.SetBool("IsDashing", _dashTime > 0);
            _anim.SetBool("IsGrounded", _isGrounded);

            _anim.SetBool("IsAttacking", _isAttacking);
            _anim.SetInteger("ComboCounter", _comboCounter);
        }

        private void CheckFlip()
        {
            if (_horizontalInput > 0 && FacingDirection != 1) Flip();
            else if (_horizontalInput < 0 && FacingDirection != -1) Flip();
        }
    }
}
