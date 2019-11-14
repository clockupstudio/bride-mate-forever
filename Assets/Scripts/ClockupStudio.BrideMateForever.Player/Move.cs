using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class Move : MonoBehaviour
    {
        public float Velocity = 0.5f;
        public MoveDirection Direction = MoveDirection.Right;

        private void Start()
        {
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector2(Velocity * (int)Direction * Time.fixedDeltaTime, 0));
        }

        public void SetDirection(MoveDirection dir)
        {
            Debug.Log($"Move to direction {dir}");
            Direction = dir;
        }
    }
}
