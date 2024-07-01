namespace Simple2DRPG.Character
{
    public class PlayerAirState : PlayerState
    {
        public PlayerAirState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
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

            if (_player.IsWallDetected) _stateMachine.ChangeState(_player.WallSlideState);
            if (_rb.velocity.y == 0) _stateMachine.ChangeState(_player.IdleState);
            if (_horizontalInput != 0) _player.SetVelocity(_player.MoveSpeed * .7f * _horizontalInput, _rb.velocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}