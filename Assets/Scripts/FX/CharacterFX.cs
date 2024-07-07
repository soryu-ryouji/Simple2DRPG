using System.Collections;
using UnityEngine;

namespace Simple2DRPG.FX
{
    public class CharacterFX : MonoBehaviour
    {
        private SpriteRenderer _sr;
        private Material _originalMat;
        [SerializeField] private Material hitMat;

        private void Awake()
        {
            _sr = GetComponentInChildren<SpriteRenderer>();
            _originalMat = _sr.material;
        }

        private IEnumerator FlashFX()
        {
            _sr.material = hitMat;
            yield return new WaitForSeconds(0.2f);
            _sr.material = _originalMat;
        }
    }
}