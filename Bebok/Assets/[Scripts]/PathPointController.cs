using UnityEngine;

public class PathPointController : MonoBehaviour {
    [SerializeField, Range(0, 3)] float minWaitTime = 1f;
    [SerializeField, Range(0, 3)] float maxWaitTime = 1f;

    public float WaitingFarThisPoint() {
        return Random.Range(minWaitTime, maxWaitTime);
    }
}
