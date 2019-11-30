﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerDead : MonoBehaviour
    {
        private Movement _movement;
        private Animator _animator;
        public GameObject input;

        void Awake()
        {
            _movement = GetComponent<Movement>();
            _animator = GetComponent<Animator>();
        }

        public void Dead()
        {
            input.SetActive(false);
            
            _movement.Disable(true);
            _animator.SetInteger("Action", 4);
        }
    }
}
