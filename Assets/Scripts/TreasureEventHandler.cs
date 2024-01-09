using UnityEngine;
using UnityEngine.Events;

public class TreasureEventHandler : MonoBehaviour
{
    public static UnityEvent OnPlayerTouch = new UnityEvent();
    public static UnityEvent OnPlayerLeave = new UnityEvent();
    public static UnityEvent OnKeyCollected = new UnityEvent();
}