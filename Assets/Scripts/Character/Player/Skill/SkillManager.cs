using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        else Instance = this;
    }
}
