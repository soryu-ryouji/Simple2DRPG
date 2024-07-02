using UnityEngine;

namespace Simple2DRPG.Character.Skill
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] protected float _cooldown;
        protected float _cooldownTimer;

        protected virtual void Update()
        {
            _cooldownTimer -= Time.deltaTime;
        }

        public virtual bool CanUseSkill()
        {
            if (_cooldownTimer < 0)
            {
                UseSkill();
                _cooldownTimer = _cooldown;
                return true;
            }

            Debug.Log($"<color=yellow>{nameof(DashSkill)} is on cooldown</color>");
            return false;
        }

        public virtual void UseSkill()
        {
        }
    }
}
