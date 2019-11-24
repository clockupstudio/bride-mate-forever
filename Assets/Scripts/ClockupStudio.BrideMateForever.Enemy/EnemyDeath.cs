using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private AudioSource _audioSource;
        private SpriteRenderer _sprite;
        private Shader _shaderGUItext;
        private Shader _shaderSpritesDefault;
        public Color paintDamageColor = new Color32(15, 56, 15, 255);

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _sprite = GetComponent<SpriteRenderer>();
            _shaderGUItext = Shader.Find("GUI/Text Shader");
            _shaderSpritesDefault = Shader.Find("Sprites/Default");
        }

        public void Death()
        {
            PaintDamage();
            StartCoroutine("PlaySound");
        }

        IEnumerator PlaySound()
        {
            _audioSource.Play();
            yield return new WaitWhile(()=> _audioSource.isPlaying);
            gameObject.SetActive(false);
        }

        private void PaintDamage()
        {
            _sprite.material.shader = _shaderGUItext;
            _sprite.color = paintDamageColor;
        }
    }
}
