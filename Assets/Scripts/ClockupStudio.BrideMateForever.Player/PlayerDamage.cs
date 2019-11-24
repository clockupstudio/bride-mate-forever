using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    public class PlayerDamage : MonoBehaviour
    {
        private Movement _movement;
        private Rigidbody2D _rb2d;
        private SpriteRenderer _sprite;
        private Shader _shaderGUItext;
        private Shader _shaderSpritesDefault;

        void Start()
        {
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
            Debug.Log("HIT");

            _movement.Disable(true);
            BounceBackward();
            PaintDamage();

            StartCoroutine("Recover");
        }

        private IEnumerator Recover()
        {
            yield return new WaitForSeconds(.3f);
            _movement.Disable(false);
            CancelBounce();
            RemovePaintDamage();
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

        private void PaintDamage()
        {
            _sprite.material.shader = _shaderGUItext;
            _sprite.color = new Color32(15, 56, 15, 255);
        }

        private void RemovePaintDamage()
        {
            _sprite.material.shader = _shaderSpritesDefault;
            _sprite.color = Color.white;
        }
    }
}
