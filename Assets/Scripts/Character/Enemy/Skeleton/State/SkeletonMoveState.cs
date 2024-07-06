namespace Simple2DRPG.Character
{
    public class SkeletonMoveState : SkeletonState
    {
        public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
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

            _enemyBase.SetVelocity(_enemyBase.FaceDirection * _enemy.moveSpeed, _enemyBase.Rigitbody.velocity.y);

            if (_enemyBase.IsWallDetected || !_enemyBase.IsGrounded)
            {
                _enemyBase.Flip();
                _enemyBase.stateMachine.ChangeState(_enemy.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}