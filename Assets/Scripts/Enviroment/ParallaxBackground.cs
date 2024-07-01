using UnityEngine;

namespace Simple2DRPG.Enviroment
{
    public class ParallaxBackground : MonoBehaviour
    {
        private GameObject _cam;
        [SerializeField] private float _parallaxEffect;
        private float _xPosition;
        private float _length;

        private void Awake()
        {
            _cam = GameObject.Find("Main Camera");

            _xPosition = transform.position.x;
        }

        private void Update()
        {
            float distanceMoved = _cam.transform.position.x * (1 - _parallaxEffect);
            float distanceToMove = _cam.transform.position.x * _parallaxEffect;

            transform.position = new Vector3(_xPosition + distanceToMove, transform.position.y);

            if (distanceMoved > _xPosition + _length)
            {
                _xPosition = _xPosition + _length;
            }
            else if (distanceMoved < _xPosition - _length)
            {
                _xPosition = _xPosition - _length;
            }
        }
    }
}