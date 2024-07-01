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

            if (!IsGrounded || IsWallDetected) Flip();

            Move();
        }

        private void Move()
        {
            if (_isPlayerDetected.distance > 1)
            {
                Rigitbody.velocity = new Vector2(_moveSpeed * 1.5f * FaceDirection, Rigitbody.velocity.y);
            }
            else if (!_isAttacking)
            {
                Rigitbody.velocity = new Vector2(_moveSpeed * FaceDirection, Rigitbody.velocity.y);
            }
        }

        protected override void CollisionCheck()
        {
            base.CollisionCheck();

            _isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, _playerCheckDistance * FaceDirection, _playerLayer);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawLine(transform.position,
                new Vector3(transform.position.x + _playerCheckDistance * FaceDirection, transform.position.y));
        }
    }
}
