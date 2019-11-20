using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{

    internal class AnimationParameters
    {
        public static readonly int Run = Animator.StringToHash("isRun");
        public static readonly int Jump = Animator.StringToHash("Jump");
    }
    [RequireComponent(typeof(Animator))]
    public class AnimationDirection : MonoBehaviour
    {
        private Animator _anim;
        private Rigidbody2D _rb2d;
        private MoveKey _dir = MoveKey.Right;

        private bool _stand = true;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            UpdateDirection();
            UpdateAnimation();
        }

        private void UpdateDirection()
        {
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (int)_dir;
            transform.localScale = scale;
        }

        private void UpdateAnimation()
        {
            _anim.SetBool(AnimationParameters.Jump, _rb2d.velocity.y != 0);
            _anim.SetBool(AnimationParameters.Run, !_stand);
        }

        public void OnPressedMovement(MoveKey dir)
        {
            if (dir == MoveKey.None)
            {
                _stand = true;
                return;
            }
            _stand = false;
            _dir = dir;
        }
    }
}
