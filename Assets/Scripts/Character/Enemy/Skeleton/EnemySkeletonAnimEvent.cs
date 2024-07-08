using UnityEngine;

namespace Simple2DRPG.Character
{
    public class EnemySkeletonAnimEvent : MonoBehaviour
    {
        private EnemySkeleton _skeleton;

        private void Awake()
        {
            _skeleton = GetComponentInParent<EnemySkeleton>();
        }

        private void TriggerAnim()
        {
            _skeleton.TriggerFinishAnim();
        }

        private void TriggerAttack()
        {
            var colliders = Physics2D.OverlapCircleAll(_skeleton.attackCheck.position, _skeleton.attackCheckRadius);
            foreach (var item in colliders)
            {
                if (item.GetComponent<Player>() != null)
                {
                    _skeleton.state.DoDamage(item.GetComponent<CharacterState>());
                }
            }
        }

        private void OpenCounterAttackWindow() => _skeleton.OpenCounterAttackWindow();
        private void CloseCounterAttackWindow() => _skeleton.CloseCounterAttackWindow();
    }
}