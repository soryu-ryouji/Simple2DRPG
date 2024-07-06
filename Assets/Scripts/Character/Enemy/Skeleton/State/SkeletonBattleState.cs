using UnityEngine;

namespace Simple2DRPG.Character
{
    public class SkeletonBattleState : SkeletonState
    {
        private Transform _playerPos;
        private int _moveDir;

        public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,
            EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _playerPos = PlayerManager.Instance.Player.transform;
        }

        public override void Update()
        {
            base.Update();

            if (_enemy.IsPlayerDetected)
            {
                _stateTimer = _enemy.battleTime;
                if (_enemy.IsPlayerDetected.distance < _enemy.attackDistance)
                {
                    if (CanAttack) _stateMachine.ChangeState(_enemy.AttackState);
                }
            }
            else
            {
                if (_stateTimer < 0 || Vector2.Distance(_playerPos.position, _enemy.transform.position) > 5)
                {
                    _stateMachine.ChangeState(_enemy.IdleState);
                }
            }

            if (_playerPos.position.x > _enemy.transform.position.x) _moveDir = 1;
            else _moveDir = -1;

            _enemyBase.SetVelocity(_enemy.moveSpeed * _moveDir, _rb.velocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }

        private bool CanAttack => Time.time >= _enemy.lastAttackTime + _enemy.attackCooldown;
    }
}