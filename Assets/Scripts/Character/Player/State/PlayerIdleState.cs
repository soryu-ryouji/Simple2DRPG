namespace Simple2DRPG.Character
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
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

            if (_horizontalInput != 0 && !_player.IsBusy) _stateMachine.ChangeState(_player.MoveState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}