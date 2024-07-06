using UnityEngine;

namespace Simple2DRPG.Character
{
    public class EnemyState
    {
        protected Enemy _enemyBase;
        protected EnemyStateMachine _stateMachine;
        protected Rigidbody2D _rb;
        private string _animBoolName;
        protected bool _triggerCalled;
        protected float _stateTimer;

        public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            _triggerCalled = false;
            _rb = _enemyBase.Rb;
            _enemyBase.Anim.SetBool(_animBoolName, true);
        }

        public virtual void Update()
        {
            _stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            _enemyBase.Anim.SetBool(_animBoolName, false);
        }

        public void TriggerFinishAnim()
        {
            _triggerCalled = true;
        }
    }
}