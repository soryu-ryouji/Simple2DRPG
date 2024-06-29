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

        [Header("Ground Check info")]
        [SerializeField] private float _groundCheckDistance = 1.4f;
        [SerializeField] private LayerMask _groundLayer;
        private bool _isGrounded;

        private float _dashSpeed = 20;
        private float _dashDuration = 0.3f;
        private float _dashTime = 0;

        private void Awake()
        {
            _animator = this.transform.GetComponentInChildren<Animator>();
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            CheckInput();
            CheckGround();

            _dashTime -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift)) _dashTime = _dashDuration;
            if (_dashTime > 0)
            {

            }
            CheckAnim();
        }

        public void Move()
        {
            if (_dashTime > 0) _rigid.velocity = new Vector2(_horizontalInput * _dashSpeed, 0);
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
        }

        private void CheckAnim()
        {
            CheckFlip();
            _animator.SetFloat("YVelocity", _rigid.velocity.y);
            _animator.SetBool("IsMoving", _horizontalInput != 0);
            _animator.SetBool("IsDashing", _dashTime > 0);
            _animator.SetBool("IsGrounded", _isGrounded);
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

        private void CheckGround()
        {
            _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - _groundCheckDistance));
        }
    }
}
