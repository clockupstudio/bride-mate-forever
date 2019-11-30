using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{

    internal class AnimationParameters
    {
        public static readonly int Blend = Animator.StringToHash("Blend");
    }

    enum ActionKind
    {
        Stand,
        Run,
        Jump,
        Slide,
    }

    [RequireComponent(typeof(Animator))]
    public class AnimationDirection : MonoBehaviour
    {
        private Animator _anim;
        private Rigidbody2D _rb2d;
        private InputHandler _handler;
        private Vector2 _dir = Vector2.right;

        private bool _stand = true;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
            _handler = GetComponent<InputHandler>();
        }

        void Update()
        {
            UpdateDirection();
            UpdateAnimation();
        }

        private void UpdateDirection()
        {
            if (_handler.MoveDirection.x == 0) return;
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * _handler.MoveDirection.x;
            transform.localScale = scale;
        }

        private void UpdateAnimation()
        {
            ActionKind kind = ActionKind.Stand;
            if (GetComponent<Slide>() != null)
            {
                kind = ActionKind.Slide;
            }
            else if (_rb2d.velocity.y != 0)
            {
                kind = ActionKind.Jump;
            }
            else if (_handler.MoveDirection != Vector2.zero)
            {
                kind = ActionKind.Run;
            }

            Debug.Log($"UpdateAnimation: resolve animation {_anim.GetInteger("Action")}");
            if (_anim.GetInteger("Action") == (int)kind)
            {
                return;
            }
            _anim.SetInteger("Action", (int)kind);
        }
    }
}
