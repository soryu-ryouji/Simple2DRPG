using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerState
    {
        protected Player _player;
        protected PlayerStateMachine _stateMachine;
        protected Rigidbody2D _rb;

        protected float _stateTimer;
        protected bool _triggerCalled;

        protected float _horizontalInput;
        protected float _verticalInput;
        private string _animBoolName;

        public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        {
            _player = player;
            _stateMachine = stateMachine;
            _animBoolName = animBoolName;

            _rb = player.Rb;
        }

        public virtual void Enter()
        {
            _player.Anim.SetBool(_animBoolName, true);
            _triggerCalled = false;
        }

        public virtual void Update()
        {
            _stateTimer -= Time.deltaTime;

            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            _player.Anim.SetFloat("YVelocity", _rb.velocity.y);
        }

        public virtual void Exit()
        {
            _player.Anim.SetBool(_animBoolName, false);
        }

        public virtual void TriggerFinishAnim()
        {
            _triggerCalled = true;
        }
    }
}