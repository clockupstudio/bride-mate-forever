using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerDead : MonoBehaviour
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

        public void Dead()
        {
            input.SetActive(false);
            _movement.Disable(true);
            _body.velocity = Vector2.zero;
            _animator.SetInteger("Action", 4);

            text.gameObject.SetActive(true);
            text.text = "Next time... maybe.";
            StartCoroutine("Ending");
        }

        public IEnumerator Ending()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Ending");
        }
    }
}
