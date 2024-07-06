namespace Simple2DRPG.Character
{
    public class SkeletonGroundedState : SkeletonState
    {
        public SkeletonGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
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
            
            if (_enemy.IsPlayerDetected) _stateMachine.ChangeState(_enemy.BattleState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}