using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClockupStudio.BrideMateForever.Player
{
    public class Direction : MonoBehaviour
    {
        public MoveDirection MoveDirection = MoveDirection.Right;

        public void SetDirection(MoveDirection dir)
        {
            Debug.Log($"Move to direction {dir}");
            MoveDirection = dir;
        }
    }

}
