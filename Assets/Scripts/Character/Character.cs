using UnityEngine;

namespace Simple2DRPG.Character
{
    public class Character : MonoBehaviour
    {
        protected Animator _anim;
        protected Rigidbody2D _rigid;

        public int FacingDirection { get; private set; } = 1;

        [Header("Ground Check info")]
        [SerializeField] protected Transform _groundCheckPos;
        [SerializeField] protected float _groundCheckDistance = 0.3f;
        [SerializeField] private LayerMask _groundLayer;
        protected bool _isGrounded;

        protected virtual void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
            _rigid = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            CheckGround();
        }

        protected void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void CheckGround()
        {
            _isGrounded = Physics2D.Raycast(_groundCheckPos.position, Vector2.down, _groundCheckDistance, _groundLayer);
        }

        protected virtual void OnDrawGizmos()
        {
            if (_groundCheckPos != null)
            {
                Gizmos.DrawLine(_groundCheckPos.position,
                    new Vector3(_groundCheckPos.position.x, _groundCheckPos.position.y - _groundCheckDistance));
            }
        }
    }
}