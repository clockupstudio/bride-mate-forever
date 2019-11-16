using System;
using UnityEngine;
using UnityEngine.Events;

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
        public KeyCode LeftKey = KeyCode.LeftArrow;
        public KeyCode RightKey = KeyCode.RightArrow;
        public KeyCode JumpKey = KeyCode.Space;

        public JumpCommand JumpCommand;
        public MoveCommand MoveCommand;

        private void Start()
        {
            JumpCommand = JumpCommand ?? new JumpCommand();
            MoveCommand = MoveCommand ?? new MoveCommand();
        }

        private void Update()
        {
            ProcessMove();
            ProcessJump();
        }

        private void ProcessJump()
        {
            if (Input.GetKey(JumpKey))
                JumpCommand.Invoke(true);
            else
                JumpCommand.Invoke(false);
        }

        private void ProcessMove()
        {
            if (Input.GetKey(LeftKey))
            {
                MoveCommand.Invoke(MoveKey.Left);
            }
            else if (Input.GetKey(RightKey))
            {
                MoveCommand.Invoke(MoveKey.Right);
            }
            else
            {
                MoveCommand.Invoke(MoveKey.None);
            }
        }
    }
}
