using UnityEngine;


namespace ClockupStudio.BrideMateForever.Player
{
    public class InputHandler : MonoBehaviour
    {
        public MoveKey MoveDirection = MoveKey.Right;

        public bool PressedJump
        {
            set; get;
        }

        public void OnPressedMovement(MoveKey dir)
        {
            MoveDirection = dir;
            Debug.Log($"move: {MoveDirection}");
        }

        public void OnPressedJump(bool pressed)
        {
            PressedJump = pressed;
        }
    }

}
