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
    }
}