using UnityEngine;

namespace Simple2DRPG.Character
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        public static PlayerController Player;

        private void Awake()
        {
            if (Instance != null) Destroy(Instance.gameObject);
            else Instance = this;
        }
    }
}
