using UnityEngine;


namespace ClockupStudio.BrideMateForever.Player
{
    public class InputHandler : MonoBehaviour
    {
        public MoveKey MoveDirection = MoveKey.None;
        public bool PressedJump;

        public void OnPressedMovement(MoveKey dir)
        {
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
