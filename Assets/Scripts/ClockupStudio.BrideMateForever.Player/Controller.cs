using UnityEngine;
using UnityEngine.Events;

namespace ClockupStudio.BrideMateForever.Player
{

    [System.Serializable]
    public class MoveDirectionEvent : UnityEvent<int>
    {
    }

    public class Controller : MonoBehaviour
    {

        public MoveDirectionEvent MoveEvent;

        // Start is called before the first frame update
        private void Start()
        {
            if (MoveEvent == null)
            {
                MoveEvent = new MoveDirectionEvent();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveEvent.Invoke(-1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveEvent.Invoke(1);
            }
            else
            {
                MoveEvent.Invoke(0);
            }
        }
    }
}
