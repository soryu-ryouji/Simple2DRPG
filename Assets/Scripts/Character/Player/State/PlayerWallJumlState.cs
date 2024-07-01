using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerWallJumpState : PlayerState
    {
        public PlayerWallJumpState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _stateTimer = .4f;
            _player.SetVelocity(5 * -_player.FaceDirection, _player.JumpForce);
        }

        public override void Update()
        {
            base.Update();

            if (_stateTimer < 0) _stateMachine.ChangeState(_player.AirState);
            if (_player.IsGrounded) _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}