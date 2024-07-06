using Simple2DRPG.FX;
using UnityEngine;
using UnityEngine.Serialization;

namespace Simple2DRPG.Character
{
    public class Character : MonoBehaviour
    {
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public CharacterFX Fx { get; private set; }

        public int FaceDirection { get; private set; } = 1;

        [Header("Collision Check info")] [SerializeField]
        private LayerMask _groundLayer;

        [Space] [SerializeField] protected Transform _groundCheck;

        [SerializeField] protected float _groundCheckDistance = 0.3f;

        [Space] [SerializeField] protected Transform _wallCheck;

        [SerializeField] protected float _wallCheckDistance = 0.7f;

        public bool IsGrounded =>
            Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);

        public bool IsWallDetected =>
            Physics2D.Raycast(_wallCheck.position, Vector2.right, _wallCheckDistance * FaceDirection, _groundLayer);

        protected virtual void Awake()
        {
            Anim = GetComponentInChildren<Animator>();
            Fx = GetComponent<CharacterFX>();
            Rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            CollisionCheck();
        }

        public void Damage(int damage)
        {
            Fx.StartCoroutine("FlashFX");
            Debug.Log($"<color=yellow>{gameObject.name} was damaged: {damage}</color>");
        }

        public void SetVelocity(float xVelocity, float YVelocity)
        {
            Rb.velocity = new Vector2(xVelocity, YVelocity);
            SetFlip(xVelocity);
        }


        private void SetFlip(float horizontal)
        {
            if (Rb.velocity.x > 0 && FaceDirection != 1) Flip();
            else if (Rb.velocity.x < 0 && FaceDirection != -1) Flip();
        }

        public void Flip()
        {
            FaceDirection *= -1;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void CollisionCheck()
        {
        }

        protected virtual void OnDrawGizmos()
        {
            if (_groundCheck != null)
            {
                Gizmos.DrawLine(_groundCheck.position,
                    new Vector3(_groundCheck.position.x, _groundCheck.position.y - _groundCheckDistance));
            }

            if (_wallCheck != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(_wallCheck.position,
                    new Vector3(_wallCheck.position.x + _wallCheckDistance * FaceDirection, _wallCheck.position.y));
                Gizmos.color = Color.white;
            }
        }
    }
}