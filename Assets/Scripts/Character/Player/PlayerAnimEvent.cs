using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerAnimEvent : MonoBehaviour
    {
        private PlayerController _player;

        private void Awake()
        {
            _player = GetComponentInParent<PlayerController>();
        }

        private void TriggerAnim()
        {
            _player.TriggerAnim();
        }
    }
}
