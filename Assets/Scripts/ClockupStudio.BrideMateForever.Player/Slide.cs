using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    // Player will slide after this component added it and automatic remove
    // after slide was done.
    [RequireComponent(typeof(Rigidbody2D))]
    public class Slide : MonoBehaviour
    {
        public float Speed = 200f;

        private const float _slideDurationSecs = 1f; // 2s.

        public Rigidbody2D Rb2D;

        public void Do(Vector2 dir)
        {
            Debug.Log($"Slide.Do: dir: {dir}");
            Rb2D.velocity = new Vector2(Speed * dir.x * Time.deltaTime, 0);
            Destroy(this, _slideDurationSecs);
        }

        private void OnDestroy()
        {
            Rb2D.velocity = Vector2.zero;
        }
    }

}
