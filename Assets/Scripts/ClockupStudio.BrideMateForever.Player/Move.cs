using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class Move : MonoBehaviour
    {
        private Rigidbody2D _rb2d;

        public float Velocity = 0.5f;
        public int Direction = 1;

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb2d.velocity = new Vector2(Velocity * Direction * Time.fixedDeltaTime, 0);
        }

        public void SetDirection(int dir) {
            Debug.Log($"Move to direction {dir}");
            Direction = dir;
        }
    }
}
