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
        public PlayerDead playerDead;
        public PlayerWin playerWin;
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Ground"))
            {
                Debug.Log("Ground");
                _body.velocity = new Vector2(0, 0);
                _body.gravityScale = 0;
                playerDead.Dead();
            }
            else if (other.gameObject.tag.Equals("Player"))
            {
                Debug.Log("Player");
                _body.velocity = new Vector2(0, 0);
                _body.gravityScale = 0;

                playerWin.Win();
                gameObject.SetActive(false);
            }
        }

        private void OnBecameInvisible()
        {
            Debug.Log("Bye...");
            _body.velocity = new Vector2(0, 0);
            _body.gravityScale = 0;
            playerDead.Dead();

            gameObject.SetActive(false);
        }
    }
}
