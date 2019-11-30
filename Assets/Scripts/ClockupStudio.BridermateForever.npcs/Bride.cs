using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.NPCs
{
    public class Bride : MonoBehaviour
    {
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Throw()
        {
            _animator.SetBool("Throw", true);
        }

        public void Idle()
        {
            _animator.SetBool("Throw", false);
        }
    }
}
