using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class Move : MonoBehaviour
    {
        private Rigidbody2D _rb2d;

        public float Velocity = 0.5f;
        public float Direction = 1;

        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rb2d.velocity = new Vector2(Velocity * Direction * Time.fixedDeltaTime, 0);
        }
    }
}
