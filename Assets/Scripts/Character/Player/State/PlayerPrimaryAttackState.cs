using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerPrimaryAttackState : PlayerState
    {
        private int _comboCounter;
        private float _lastAttackTime;
        private float _comboWindow = 2;
        public PlayerPrimaryAttackState(PlayerController player, PlayerStateMachine stateMachine, string animBoolName)
            : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if (_comboCounter > 2 || Time.unscaledTime > _lastAttackTime + _comboWindow)
            {
                _comboCounter = 0;
            }

            float attackDirection = _player.FaceDirection;
            if (_horizontalInput != 0) attackDirection = _horizontalInput;

            _player.Anim.SetInteger("ComboCounter", _comboCounter);
            var attackMovement = _player.PrimaryAttackMovement[_comboCounter];
            _player.SetVelocity(attackMovement.x * attackDirection, attackMovement.y);
            _stateTimer = 0.1f;
        }

        public override void Update()
        {
            base.Update();

            if (_stateTimer < 0) _rb.velocity = new Vector2(0, 0);
            if (_triggerCalled) _stateMachine.ChangeState(_player.IdleState);
        }

        public override void Exit()
        {
            base.Exit();
            _player.StartCoroutine("BusyFor", 0.15f);
            _comboCounter++;
            _lastAttackTime = Time.unscaledTime;
        }
    }
}