using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockupStudio.BrideMateForever.Player;

namespace ClockupStudio.BrideMateForever.NPCs
{
    public class Bride : MonoBehaviour
    {
        private Animator _animator;
        public Flower flower;
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Throw()
        {
            _animator.SetBool("Throw", true);
        }

        public void ThrowEnd()
        {
            flower.Launch();
        }

        public void Idle()
        {
            _animator.SetBool("Throw", false);
        }
    }
}
