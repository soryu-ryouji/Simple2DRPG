namespace Simple2DRPG.Character
{
    public class SkeletonState : EnemyState
    {
        protected EnemySkeletonController _enemy;
        public SkeletonState(EnemyController enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeletonController enemy)
            : base(enemyBase, stateMachine, animBoolName)
        {
            _enemy = enemy;
        }
    }
}