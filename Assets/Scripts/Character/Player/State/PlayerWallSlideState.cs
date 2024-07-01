using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerWallSlideState : PlayerState
    {
        public PlayerWallSlideState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            // 上方向键时，下落会更慢
            // 下方向键，下落会更快
            if (_verticalInput > 0)
            {
                _player.SetVelocity(0, _rb.velocity.y * 0.1f);
            }
            else if (_verticalInput! < 0)
            {
                _player.SetVelocity(0, _rb.velocity.y);
            }
            else
            {
                _player.SetVelocity(0, _rb.velocity.y * 0.8f);
            }

            if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_player.WallJumpState);
            if (_player.IsGrounded) _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}