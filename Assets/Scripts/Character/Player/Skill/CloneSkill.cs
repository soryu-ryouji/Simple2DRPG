using UnityEngine;

namespace Simple2DRPG.Character.Skill
{
    public class CloneSkill : Skill
    {
        [SerializeField] private GameObject _clonePrefabs;

        public override void UseSkill()
        {
            var clone = Instantiate(_clonePrefabs);
            clone.transform.position = PlayerManager.Instance.Player.transform.position;
            clone.GetComponent<CloneSkillController>().SetupClone(cloneDuration: 2, true);
        }
    }
}
