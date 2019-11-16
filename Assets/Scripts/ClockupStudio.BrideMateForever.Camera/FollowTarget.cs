using UnityEngine;

namespace ClockupStudio.BrideMateForever.Camera
{
    public class FollowTarget : MonoBehaviour
    {

        // Target to following
        public GameObject Target;

        private Vector3 _pos;

        private void Start()
        {
            _pos = transform.position;
        }

        void Update()
        {
            transform.position = Target.transform.position + _pos;
        }
    }
}
