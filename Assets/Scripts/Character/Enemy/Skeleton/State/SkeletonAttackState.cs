using UnityEngine;

namespace Simple2DRPG.Character
{
    public class SkeletonAttackState : SkeletonState
    {
        public SkeletonAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            _enemy.SetVelocity(0, 0);

            if (_triggerCalled) _stateMachine.ChangeState(_enemy.BattleState);
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.lastAttackTime = Time.time;
        }
    }
}