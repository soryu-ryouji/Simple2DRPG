using Simple2DRPG.Character.Skill;

namespace Simple2DRPG.Character
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            _stateTimer = _player.dashDuration;
            base.Enter();
            SkillManager.Instance.CloneSkill.CanUseSkill();
        }

        public override void Update()
        {
            base.Update();

            _player.SetVelocity(_player.dashSpeed * _player.FaceDirection, 0);

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