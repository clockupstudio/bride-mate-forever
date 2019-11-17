using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace ClockupStudio.BrideMateForever.Player
{

    [System.Serializable]
    public class JumpCommand : UnityEvent<bool>
    {
    }

    [System.Serializable]
    public class MoveCommand : UnityEvent<MoveKey>
    {
    }

    public enum MoveKey
    {
        None = 0,
        Left = -1,
        Right = 1,
    }

    public class Controller : MonoBehaviour
    {
        // All available controller keys.
        public JumpCommand JumpCommand;
        public MoveCommand MoveCommand;

        private void Start()
        {
            JumpCommand = JumpCommand ?? new JumpCommand();
            MoveCommand = MoveCommand ?? new MoveCommand();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            var vec2 = ctx.ReadValue<Vector2>();
            Debug.Log(vec2);
            if (vec2 == Vector2.left)
                MoveCommand.Invoke(MoveKey.Left);
            else if (vec2 == Vector2.right)
                MoveCommand.Invoke(MoveKey.Right);
            else
                MoveCommand.Invoke(MoveKey.None);
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            Debug.Log($"action phase: {ctx.phase}");
            switch (ctx.phase)
            {
                case InputActionPhase.Performed:
                    JumpCommand.Invoke(true);
                    return;
            }
        }
    }
}
