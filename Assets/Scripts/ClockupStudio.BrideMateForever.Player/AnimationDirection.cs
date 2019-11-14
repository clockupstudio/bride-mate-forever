using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.Player
{
    [RequireComponent(typeof(Direction))]
    public class AnimationDirection : MonoBehaviour
    {
        private Direction _dircomp;

        // Start is called before the first frame update
        void Start()
        {
            _dircomp = GetComponent<Direction>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_dircomp.MoveDirection == MoveDirection.NoMove) return;

            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (int)_dircomp.MoveDirection;
            transform.localScale = scale;
        }
    }
}
