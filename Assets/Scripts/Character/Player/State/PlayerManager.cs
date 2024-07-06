using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        public PlayerController Player;

        private void Awake()
        {
            if (Instance != null) Destroy(Instance.gameObject);
            else Instance = this;
        }
    }
}
