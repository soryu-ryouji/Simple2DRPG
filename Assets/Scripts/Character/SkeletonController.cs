using UnityEngine;

namespace Simple2DRPG.Character
{
    public class SkeletonController : Character
    {
        [Header("Move info")]
        [SerializeField] private float _moveSpeed = 3;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (!_isGrounded) Flip();

            _rigid.velocity = new Vector2(_moveSpeed * FacingDirection, _rigid.velocity.y);
        }
    }
}
