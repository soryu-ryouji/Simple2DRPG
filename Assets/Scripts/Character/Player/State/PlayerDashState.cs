namespace Simple2DRPG.Character
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            _stateTimer = _player.DashDuration;
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            _player.SetVelocity(_player.DashSpeed * _player.FaceDirection, 0);

            if (!_player.IsGrounded && _player.IsWallDetected) _stateMachine.ChangeState(_player.WallSlideState);
            if (_stateTimer < 0) _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
            _player.SetVelocity(0, _rb.velocity.y);
        }
    }
}