using UnityEngine;

namespace Simple2DRPG.Character
{
    public class EnemySkeleton : Enemy
    {
        [Header("Attack info")]
        public Transform attackCheck;
        public float attackCheckRadius;

        public SkeletonIdleState IdleState { get; private set; }
        public SkeletonMoveState MoveState { get; private set; }
        public SkeletonBattleState BattleState { get; private set; }
        public SkeletonAttackState AttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            IdleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
            MoveState = new SkeletonMoveState(this, stateMachine, "Move", this);
            BattleState = new SkeletonBattleState(this, stateMachine, "Move", this);
            AttackState = new SkeletonAttackState(this, stateMachine, "Attack", this);

            stateMachine.Initialize(IdleState);
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
        }
    }
}