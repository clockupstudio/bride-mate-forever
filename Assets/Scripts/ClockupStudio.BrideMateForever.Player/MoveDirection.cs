using UnityEngine.Events;

namespace ClockupStudio.BrideMateForever.Player
{
    public enum MoveDirection
    {
        Left = -1,
        NoMove = 0,
        Right = 1,
    }

    [System.Serializable]
    public class MoveDirectionEvent : UnityEvent<MoveDirection>
    {
    }
}
