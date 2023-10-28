using UnityEngine;

public class PathPointController : MonoBehaviour
{
    [SerializeField] float waitingNearThisPoint = 1f;
    public float WaitingFarThisPoint()
    {
        return waitingNearThisPoint;
    }
}
