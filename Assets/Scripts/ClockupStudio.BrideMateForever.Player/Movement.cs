using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(InputHandler))]
    public class Movement : MonoBehaviour
    {
        public Vector2 Velocity = new Vector2(50f, 10f);

        private InputHandler _handler;
        private Rigidbody2D _rb2d;

        private void Start()
        {
            _handler = GetComponent<InputHandler>();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var vec2 = _rb2d.velocity;
            vec2.x = Velocity.x * (int)_handler.MoveDirection * Time.fixedDeltaTime;
            if (_handler.PressedJump)
            {
                vec2.y += _rb2d.mass + (Velocity.y * Physics2D.gravity.y * Time.fixedDeltaTime);
                _handler.PressedJump = false;
            }
            _rb2d.velocity = vec2;
        }
    }
}
