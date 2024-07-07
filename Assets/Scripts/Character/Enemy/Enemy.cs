using System;
using UnityEngine;

namespace Simple2DRPG.Character
{
    public class Enemy : Character
    {
        [SerializeField] protected LayerMask playerLayer;

        [Header("Stunned info")]
        public float stunnedDuration;
        public Vector2 stunnedDirection;

        protected bool canBeStunned;
        
        [Header("Move info")]
        public float moveSpeed = 4;
        public float idleTime = 2;

        [Header("Attack info")]
        public float attackDistance;
        public float attackCooldown;
        [HideInInspector] public float lastAttackTime;

        public float battleTime;
        public EnemyStateMachine stateMachine;

        protected override void Awake()
        {
            base.Awake();
            stateMachine = new EnemyStateMachine();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            stateMachine.CurrentState.Update();
        }

        public virtual void OpenCounterAttackWindow()
        {
            canBeStunned = true;
        }

        public virtual void CloseCounterAttackWindow()
        {
            canBeStunned = false;
        }

        public virtual bool CanBeStunned()
        {
            if (canBeStunned)
            {
                CloseCounterAttackWindow();
                return true;
            }

            return false;
        }

        public virtual RaycastHit2D IsPlayerDetected =>
            Physics2D.Raycast(_wallCheck.position, Vector2.right * FaceDirection, 50, playerLayer);

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position,
                new Vector3(transform.position.x + attackDistance * FaceDirection, transform.position.y));
            Gizmos.color = Color.white;
        }
        
        public void TriggerFinishAnim() => stateMachine.CurrentState.TriggerFinishAnim();
    }
}