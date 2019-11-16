using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(InputHandler))]
    public class AnimationDirection : MonoBehaviour
    {
        private InputHandler _handler;

        void Start()
        {
            _handler = GetComponent<InputHandler>();
        }

        void Update()
        {
            if (_handler.MoveDirection == MoveKey.None) return;

            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (int)_handler.MoveDirection;
            transform.localScale = scale;
        }
    }
}
