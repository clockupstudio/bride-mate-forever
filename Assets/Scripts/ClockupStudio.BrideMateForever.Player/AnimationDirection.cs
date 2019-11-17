using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class AnimationDirection : MonoBehaviour
    {
        private InputHandler _handler;
        private MoveKey _dir = MoveKey.Right;

        void Update()
        {
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (int)_dir;
            transform.localScale = scale;
        }

        public void OnPressedMovement(MoveKey dir)
        {
            if (dir == MoveKey.None)
            {
                return;
            }
            _dir = dir;
        }
    }
}
