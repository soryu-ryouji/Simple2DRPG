using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _rb.velocity = new Vector2(_rb.velocity.x, _player.JumpForce);
        }

        public override void Update()
        {
            base.Update();

            if (_player.IsGrounded) _stateMachine.ChangeState(_player.AirState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}