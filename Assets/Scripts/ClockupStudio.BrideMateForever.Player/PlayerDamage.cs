using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        private Movement _movement;
        private Rigidbody2D _rb2d;

        void Start()
        {
            _movement = GetComponent<Movement>();
            _rb2d = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.gameObject.tag.Equals("Enemy"))
            {
                return;
            }
            Debug.Log("HIT");

            _movement.Disable(true);
            BounceBackward();

            StartCoroutine("Recover");
        }

        private IEnumerator Recover()
        {
            yield return new WaitForSeconds(.2f);
            Debug.Log("RECOVER");
            _movement.Disable(false);
            CancelBounce();
        }

        private void BounceBackward()
        {
            var vec2 = _rb2d.velocity;
            vec2.x = -4 * transform.localScale.x;
            vec2.y = 0;
            _rb2d.velocity = vec2;
        }

        private void CancelBounce()
        {
            var vec2 = _rb2d.velocity;
            vec2.x = 0;
            vec2.y = 0;
            _rb2d.velocity = vec2;
        }
    }
}
