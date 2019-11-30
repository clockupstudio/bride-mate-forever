using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockupStudio.BrideMateForever.Player;

namespace ClockupStudio.BrideMateForever.NPCs
{
    public class Flower : MonoBehaviour
    {
        private Rigidbody2D _body;
        public Movement movement;
        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            gameObject.SetActive(false);
        }

        public void Launch()
        {
            gameObject.SetActive(true);
            movement.Disable(false);
            _body.velocity = new Vector2(
                Random.Range(-1f, -10f),
                Random.Range(4f, 12f)
            );
        }
    }
}
