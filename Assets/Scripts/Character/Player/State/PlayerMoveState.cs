namespace Simple2DRPG.Character
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            if (_player.IsWallDetected) _stateMachine.ChangeState(_player.IdleState);
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            _player.SetVelocity(_horizontalInput * _player.moveSpeed, _rb.velocity.y);

            if (_horizontalInput == 0 || _player.IsWallDetected) _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}