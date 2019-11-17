using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(Animator))]
    public class AnimationDirection : MonoBehaviour
    {
        private Animator _anim;
        private MoveKey _dir = MoveKey.Right;

        private int _isRunParam = Animator.StringToHash("isRun");
        private bool _stand = true;

        private void Start()
        {
            _anim = GetComponent<Animator>();
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
            _anim.SetBool(_isRunParam, !_stand);
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
