using UnityEngine;

namespace Simple2DRPG.Character
{
    public class SkeletonStunnedState : SkeletonState
    {
        public SkeletonStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _stateTimer = _enemyBase.stunnedDuration;
            _enemy.SetVelocity(-_enemy.FaceDirection * _enemy.stunnedDirection.x, _enemy.stunnedDirection.y);
        }

        public override void Update()
        {
            base.Update();
            
            if (_stateTimer < 0) _stateMachine.ChangeState(_enemy.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}