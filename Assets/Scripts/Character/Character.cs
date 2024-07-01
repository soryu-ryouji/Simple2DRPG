using UnityEngine;

namespace Simple2DRPG.Character
{
    public class Character : MonoBehaviour
    {
        public Animator Anim;
        public Rigidbody2D Rigitbody { get; protected set; }

        public int FaceDirection { get; private set; } = 1;

        [Header("Collision Check info")]
        [SerializeField] private LayerMask _groundLayer;
        [Space]
        [SerializeField] protected Transform _groundCheckPos;
        [SerializeField] protected float _groundCheckDistance = 0.3f;
        [Space]
        [SerializeField] protected Transform _wallCheckPos;
        [SerializeField] protected float _wallCheckDistance = 0.7f;
        public bool IsGrounded =>
            Physics2D.Raycast(_groundCheckPos.position, Vector2.down, _groundCheckDistance, _groundLayer);
        public bool IsWallDetected =>
            Physics2D.Raycast(_wallCheckPos.position, Vector2.right, _wallCheckDistance * FaceDirection, _groundLayer);

        protected virtual void Awake()
        {
            Anim = GetComponentInChildren<Animator>();
            Rigitbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            CollisionCheck();
        }

        protected void Flip()
        {
            FaceDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void CollisionCheck()
        {
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
                    new(_wallCheckPos.position.x + _wallCheckDistance * FaceDirection, _wallCheckPos.position.y));
            }
        }
    }
}