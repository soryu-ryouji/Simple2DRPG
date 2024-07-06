using UnityEngine;

namespace Simple2DRPG.Character.Skill
{
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager Instance;

        public DashSkill DashSkill { get; private set; }
        public CloneSkill CloneSkill { get; private set; }

        private void Awake()
        {
            if (Instance != null) Destroy(Instance.gameObject);
            else Instance = this;
        }

        private void Start()
        {
            DashSkill = GetComponent<DashSkill>();
            CloneSkill = GetComponent<CloneSkill>();
        }
    }
}
