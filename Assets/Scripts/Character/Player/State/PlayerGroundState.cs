using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerGroundState : PlayerState
    {
        public PlayerGroundState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
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

            if (!_player.IsGrounded) _stateMachine.ChangeState(_player.AirState);
            if (Input.GetKeyDown(KeyCode.J)) _stateMachine.ChangeState(_player.PrimaryAttackState);
            if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded) _stateMachine.ChangeState(_player.JumpState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}