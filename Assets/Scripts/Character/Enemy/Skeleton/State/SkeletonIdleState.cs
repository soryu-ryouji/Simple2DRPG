namespace Simple2DRPG.Character
{
    public class SkeletonIdleState : SkeletonGroundedState
    {
        public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeleton enemy)
            : base(enemyBase, stateMachine, animBoolName, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _stateTimer = _enemy.idleTime;
        }

        public override void Update()
        {
            base.Update();

            if (_stateTimer < 0) _stateMachine.ChangeState(_enemy.MoveState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}