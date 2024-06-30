using UnityEngine;

namespace Simple2DRPG.Character
{
    public class Character : MonoBehaviour
    {
        protected Animator _anim;
        protected Rigidbody2D _rigid;

        public int FacingDirection { get; private set; } = 1;

        [Header("Collision Check info")]
        [SerializeField] private LayerMask _groundLayer;
        [Space]
        [SerializeField] protected Transform _groundCheckPos;
        [SerializeField] protected float _groundCheckDistance = 0.3f;
        [Space]
        [SerializeField] protected Transform _wallCheckPos;
        [SerializeField] protected float _wallCheckDistance = 0.7f;
        protected bool _isGrounded;
        protected bool _isWallDetected;

        protected virtual void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
            _rigid = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            CollisionCheck();
        }

        protected void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void CollisionCheck()
        {
            if (_groundCheckPos != null)
            {
                _isGrounded = Physics2D.Raycast(
                    _groundCheckPos.position, Vector2.down, _groundCheckDistance, _groundLayer);
            }

            if (_wallCheckPos != null)
            {
                _isWallDetected = Physics2D.Raycast(
                    _wallCheckPos.position, Vector2.right, _wallCheckDistance * FacingDirection, _groundLayer);
            }
        }

        protected virtual void OnDrawGizmos()
        {
            if (_groundCheckPos != null)
            {
                Gizmos.DrawLine(_groundCheckPos.position,
                    new Vector3(_groundCheckPos.position.x, _groundCheckPos.position.y - _groundCheckDistance));
            }
            if (_wallCheckPos != null)
            {
                Gizmos.DrawLine(_wallCheckPos.position,
                    new(_wallCheckPos.position.x + _wallCheckDistance * FacingDirection, _wallCheckPos.position.y));
            }
        }
    }
}