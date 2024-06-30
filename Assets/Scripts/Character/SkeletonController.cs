using UnityEngine;

namespace Simple2DRPG.Character
{
    public class SkeletonController : Character
    {
        [Header("Move info")]
        [SerializeField] private float _moveSpeed = 3;

        [Header("Player detection")]
        [SerializeField] private float _playerCheckDistance;
        [SerializeField] private LayerMask _playerLayer;
        private RaycastHit2D _isPlayerDetected;

        private bool _isAttacking;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (_isPlayerDetected)
            {
                Debug.Log("111111");
                if (_isPlayerDetected.distance > 1)
                {
                    Debug.Log("I see player");
                    _isAttacking = false;
                }
                else
                {
                    // Attack
                    Debug.Log("Skeleton attacking");
                    _isAttacking = true;
                }
            }

            if (!_isGrounded || _isWallDetected) Flip();

            Move();
        }

        private void Move()
        {
            if (_isPlayerDetected.distance > 1)
            {
                _rigid.velocity = new Vector2(_moveSpeed * 1.5f * FacingDirection, _rigid.velocity.y);
            }
            else if (!_isAttacking)
            {
                _rigid.velocity = new Vector2(_moveSpeed * FacingDirection, _rigid.velocity.y);
            }
        }

        protected override void CollisionCheck()
        {
            base.CollisionCheck();

            _isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, _playerCheckDistance * FacingDirection, _playerLayer);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawLine(transform.position,
                new Vector3(transform.position.x + _playerCheckDistance * FacingDirection, transform.position.y));
        }
    }
}
