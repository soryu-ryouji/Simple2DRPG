using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerCounterAttackState : PlayerState
    {
        public PlayerCounterAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(
            player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _stateTimer = _player.counterAttackDuration;
            _player.Anim.SetBool("SuccessfulCounterAttack", false);
        }

        public override void Update()
        {
            base.Update();

            var collisions = Physics2D.OverlapCircleAll(_player.attackCheck.position, _player.attackCheckRadius);

            foreach (var item in collisions)
            {
                if (item.GetComponent<Enemy>() != null)
                {
                    _stateTimer = 10;
                    item.GetComponent<Enemy>().CanBeStunned();
                    _player.Anim.SetBool("SuccessfulCounterAttack", true);
                }
            }

            if (_stateTimer < 0 || _triggerCalled)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}