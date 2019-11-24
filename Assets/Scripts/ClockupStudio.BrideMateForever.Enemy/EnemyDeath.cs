using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockupStudio.BrideMateForever.SpriteUtils;

namespace ClockupStudio.BrideMateForever.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private AudioSource _audioSource;
        private PaintDamage _paintDamage;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _paintDamage = GetComponent<PaintDamage>();
        }

        public void Death()
        {
            _paintDamage.AddPaintDamage();
            StartCoroutine("PlaySound");
        }

        IEnumerator PlaySound()
        {
            _audioSource.Play();
            yield return new WaitWhile(()=> _audioSource.isPlaying);
            gameObject.SetActive(false);
            _paintDamage.RemovePaintDamage();
        }

    }
}
