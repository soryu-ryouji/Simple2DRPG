namespace Simple2DRPG.Character
{
    public class PlayerAirState : PlayerState
    {
        public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName)
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

            if (_player.IsGrounded) _stateMachine.ChangeState(_player.IdleState);
            if (_player.IsWallDetected) _stateMachine.ChangeState(_player.WallSlideState);
            if (_horizontalInput != 0) _player.SetVelocity(_player.moveSpeed * .7f * _horizontalInput, _rb.velocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}