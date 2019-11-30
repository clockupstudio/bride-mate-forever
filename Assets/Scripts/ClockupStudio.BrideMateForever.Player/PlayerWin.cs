using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerWin : MonoBehaviour
    {
        private Movement _movement;
        private Animator _animator;
        private Rigidbody2D _body;

        public GameObject input;
        public TextMeshProUGUI text;
        void Awake()
        {
            _movement = GetComponent<Movement>();
            _animator = GetComponent<Animator>();
            _body = GetComponent<Rigidbody2D>();
        }

        public void Win()
        {
            input.SetActive(false);
            _movement.Disable(true);
            _body.velocity = Vector2.zero;
            _animator.SetInteger("Action", 5);

            text.gameObject.SetActive(true);
            text.text = "YEAAAHHH!!";
        }
    }
}
