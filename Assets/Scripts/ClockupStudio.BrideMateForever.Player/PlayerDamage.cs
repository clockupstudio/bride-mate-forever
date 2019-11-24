using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        private AudioSource _audio;
        private Movement _movement;
        private Rigidbody2D _rb2d;
        private SpriteRenderer _sprite;
        private Shader _shaderGUItext;
        private Shader _shaderSpritesDefault;

        public float bounceBack = -4f;
        public float bounceBackDelay = .3f;
        public Color paintDamageColor = new Color32(15, 56, 15, 255);
        public float bounceUp = 16f;
        public float bounceUpDelay = .1f;

        void Start()
        {
            _audio = GetComponent<AudioSource>();
            _movement = GetComponent<Movement>();
            _rb2d = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _shaderGUItext = Shader.Find("GUI/Text Shader");
            _shaderSpritesDefault = Shader.Find("Sprites/Default");
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.gameObject.tag.Equals("Enemy"))
            {
                return;
            }

            foreach (ContactPoint2D point in other.contacts)
            {
                if (point.normal.y == 0)
                {
                    Hurt();
                }
                else
                {
                    BounceUp();
                    StartCoroutine("CancelBounceUp");
                    other.gameObject.SetActive(false);
                }
            }
        }

        private void Hurt()
        {
            _audio.Play();
            _movement.Disable(true);
            BounceBackward();
            PaintDamage();

            StartCoroutine("Recover");
        }

        private IEnumerator Recover()
        {
            yield return new WaitForSeconds(bounceBackDelay);
            _movement.Disable(false);
            CancelBounce();
            RemovePaintDamage();
        }

        private void BounceBackward()
        {
            var vec2 = _rb2d.velocity;
            vec2.x = bounceBack * transform.localScale.x;
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

        private void PaintDamage()
        {
            _sprite.material.shader = _shaderGUItext;
            _sprite.color = paintDamageColor;
        }

        private void RemovePaintDamage()
        {
            _sprite.material.shader = _shaderSpritesDefault;
            _sprite.color = Color.white;
        }

        private void BounceUp()
        {
            var vec2 = _rb2d.velocity;
            vec2.y = bounceUp;
            _rb2d.velocity = vec2;
        }

        private IEnumerator CancelBounceUp()
        {
            yield return new WaitForSeconds(bounceUpDelay);
            var vec2 = _rb2d.velocity;
            vec2.y = 0;
            _rb2d.velocity = vec2;
        }
    }
}
