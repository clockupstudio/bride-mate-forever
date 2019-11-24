using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Enemy
{
    public class Patrol : MonoBehaviour
    {
        public float speed;
        public float distance;
        private bool _isMoveRight = false;
        public Transform groundDetection;
        void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if(_isMoveRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    _isMoveRight = false;
                }
                else 
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    _isMoveRight = true;
                }
            }
        }
    }
}
