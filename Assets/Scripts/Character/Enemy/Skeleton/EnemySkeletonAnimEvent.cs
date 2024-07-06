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
                if (item.GetComponent<Character>() != null) item.GetComponent<Character>().Damage(10);
            }
        }
    }
}