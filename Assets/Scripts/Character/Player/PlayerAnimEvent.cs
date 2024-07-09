using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerAnimEvent : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponentInParent<Player>();
        }

        private void TriggerAnim()
        {
            _player.TriggerAnim();
        }

        private void TriggerAttack()
        {
            var colliders = Physics2D.OverlapCircleAll(_player.attackCheck.position, _player.attackCheckRadius);
            foreach (var item in colliders)
            {
                if (item.GetComponent<CharacterState>() != null)
                {
                    _player.state.DoDamage(item.GetComponent<CharacterState>());
                }
            }
        }
    }
}