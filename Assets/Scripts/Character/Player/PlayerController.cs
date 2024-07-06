using System.Collections;
using UnityEngine;
using Simple2DRPG.Character.Skill;
using UnityEngine.Serialization;

namespace Simple2DRPG.Character
{
    public class PlayerController : Character
    {
        [Header("Attack info")]
        public Vector2[] primaryAttackMovement = { new(3, 1.5f), new(1, 2.5f), new(4, 1.5f) };

        [Header("Move info")]
        public float jumpForce = 25;
        public float moveSpeed = 10;

        [Header("Dash info")]
        public float dashSpeed = 20;
        public float dashDuration = 0.3f;
        public float DashDirection { get; private set; }

        public bool IsBusy { get; private set; } = false;

        private PlayerStateMachine _stateMachine;
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerAirState AirState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerWallJumpState WallJumpState { get; private set; }
        public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _stateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, _stateMachine, "Idle");
            MoveState = new PlayerMoveState(this, _stateMachine, "Move");
            JumpState = new PlayerJumpState(this, _stateMachine, "Jump");
            AirState = new PlayerAirState(this, _stateMachine, "Jump");
            DashState = new PlayerDashState(this, _stateMachine, "Dash");
            WallSlideState = new PlayerWallSlideState(this, _stateMachine, "WallSlide");
            WallJumpState = new PlayerWallJumpState(this, _stateMachine, "Jump");
            PrimaryAttackState = new PlayerPrimaryAttackState(this, _stateMachine, "PrimaryAttack");
        }

        protected override void Start()
        {
            base.Start();

            _stateMachine.Initialize(IdleState);
        }

        protected override void Update()
        {
            base.Update();

            // _dashTime -= Time.deltaTime;
            // _dashCooldownTimer -= Time.deltaTime;
            // _comboTimeWindow -= Time.deltaTime;

            _stateMachine.CurrentState.Update();
            CheckDash();
        }

        public IEnumerator BusyFor(float busySeconds)
        {
            IsBusy = true;
            yield return new WaitForSecondsRealtime(busySeconds);
            IsBusy = false;
        }



        private void CheckDash()
        {
            if (IsWallDetected) return;

            if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.Instance.DashSkill.CanUseSkill())
            {
                DashDirection = Input.GetAxis("Horizontal");
                if (DashDirection == 0) DashDirection = FaceDirection;

                _stateMachine.ChangeState(DashState);
            }
        }

        public void TriggerAnim() => _stateMachine.CurrentState.TriggerFinishAnim();

        // private void Attack()
        // {
        //     if (!_isGrounded) return;

        //     if (_comboTimeWindow < 0) _comboCounter = 0;
        //     _isAttacking = true;
        //     _comboTimeWindow = _comboTime;
        // }

        // public void AttackOver()
        // {
        //     _isAttacking = false;
        //     _comboCounter++;
        //     if (_comboCounter > 2) _comboCounter = 0;
        // }
    }
}