using UnityEngine;
using Unity.Mathematics;


namespace ClockupStudio.BrideMateForever.Player
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 MoveDirection = Vector2.zero;
        public bool PressedJump;

        public void OnPressedMovement(Vector2 dir)
        {
            dir.x = dir.x < 0 ? -math.ceil(-dir.x) : math.ceil(dir.x);
            dir.y = dir.y < 0 ? -math.ceil(-dir.y) : math.ceil(dir.y);
            MoveDirection = dir;
        }

        public void OnPressedJump(bool pressed)
        {
            // preventing pressed holding.
            if (PressedJump) return;
            PressedJump = pressed;
        }
    }

}
