using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.NPCs
{
    public class Flower : MonoBehaviour
    {
        private Rigidbody2D _body;

        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            gameObject.SetActive(false);
        }

        public void Launch()
        {
            gameObject.SetActive(true);
            _body.velocity = new Vector2(
                Random.Range(-1f, -10f),
                Random.Range(4f, 12f) 
            );
        }
    }
}
