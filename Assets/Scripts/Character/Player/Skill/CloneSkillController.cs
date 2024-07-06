using UnityEngine;

namespace Simple2DRPG.Character.Skill
{
    public class CloneSkillController : MonoBehaviour
    {
        private SpriteRenderer _sr;
        private Animator _anim;
        [SerializeField] private float fadingSpeed = 100;
        private float _cloneTimer;

        [SerializeField] private Transform _attackCheckPos;
        [SerializeField] private float _attackCheckRadius = 0.8f;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            _cloneTimer -= Time.deltaTime;
            if (_cloneTimer < 0)
            {
                _sr.color = new Color(1, 1, 1, _sr.color.a - (Time.deltaTime * fadingSpeed));
            }

            if (_sr.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void SetupClone(float cloneDuration, bool canAttack)
        {
            if (canAttack) _anim.SetInteger("AttackNumber", Random.Range(1, 3));
            _cloneTimer = cloneDuration;
        }

        private void TriggerAttack()
        {
            var colliders = Physics2D.OverlapCircleAll(_attackCheckPos.position, _attackCheckRadius);
            foreach (var hit in colliders)
            {
                // 获取对方身上的Character属性，并扣除生命值。
            }
        }

        private void TriggerAnim()
        {
            _cloneTimer = 0;
        }
    }
}