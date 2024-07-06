namespace Simple2DRPG.Character
{
    public class SkeletonState : EnemyState
    {
        protected EnemySkeleton _enemy;
        public SkeletonState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeleton enemy)
            : base(enemyBase, stateMachine, animBoolName)
        {
            _enemy = enemy;
        }
    }
}