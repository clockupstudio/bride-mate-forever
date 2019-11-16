using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(InputHandler))]
    public class Movement : MonoBehaviour
    {
        public float Velocity = 0.5f;

        private InputHandler _handler;

        private void Start()
        {
            _handler = GetComponent<InputHandler>();
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector2(Velocity * (int)_handler.MoveDirection * Time.fixedDeltaTime, 0));
        }
    }
}
