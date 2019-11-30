using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(InputHandler))]
    public class Movement : MonoBehaviour
    {
        public Vector2 Velocity = new Vector2(50f, 10f);

        private InputHandler _handler;
        private Rigidbody2D _rb2d;

        private Animator _anim;

        private bool _isDisabled = false;

        private void Start()
        {
            _handler = GetComponent<InputHandler>();
            _rb2d = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (_isDisabled)
            {
                return;
            }

            // do not override slide if it's still appear.
            if (GetComponent<Slide>() != null)
            {
                return;
            }

            // means slide.
            if (_handler.MoveDirection.y == -1 && _handler.PressedJump && GetComponent<Slide>() == null)
            {
                Slide slide = gameObject.AddComponent<Slide>();
                slide.Rb2D = _rb2d;
                slide.Do(_handler.MoveDirection);
                // reset input.
                _handler.MoveDirection.y = 0;
                _handler.PressedJump = false;
                return;
            }

            var vec2 = _rb2d.velocity;
            vec2.x = Velocity.x * _handler.MoveDirection.x * Time.fixedDeltaTime;
            if (_handler.PressedJump)
            {
                vec2.y += _rb2d.mass + (Velocity.y * Physics2D.gravity.y * Time.fixedDeltaTime);
                _handler.PressedJump = false;
            }
            _rb2d.velocity = vec2;
        }

        public void Disable(bool isDisable)
        {
            _isDisabled = isDisable;
        }
    }
}
