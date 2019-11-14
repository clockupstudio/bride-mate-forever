using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(Direction))]
    public class Move : MonoBehaviour
    {
        public float Velocity = 0.5f;

        private Direction _dircomp;

        private void Start()
        {
            _dircomp = GetComponent<Direction>();
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector2(Velocity * (int)_dircomp.MoveDirection * Time.fixedDeltaTime, 0));
        }
    }
}
