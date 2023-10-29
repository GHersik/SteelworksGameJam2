using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    [SerializeField] Transform pathPoint;
    [SerializeField] List<Transform> targetPoints;
    [SerializeField] PathPointsCollection pathPointsCollection;
    [SerializeField] Animator animator;

    NavMeshAgent agent;
    PathPointController pathPointController;

    private void Start() {
        pathPointsCollection = FindAnyObjectByType<PathPointsCollection>();
        targetPoints = pathPointsCollection.ListPoints();
        agent = GetComponent<NavMeshAgent>();
        pathPoint = GetRandomTargetPoint();
        StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
    }
<<<<<<< HEAD
    private void Update()
    {
        if (!agent.hasPath)
        {
=======
    private void Update() {
        if (!agent.hasPath) {
>>>>>>> develop
            pathPoint = GetRandomTargetPoint();
            StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
        }

        animator.SetBool("isWalking", agent.hasPath);
    }

    public void SetPathToBebok(Transform bebok) {
        pathPoint = bebok;
        StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public void SetPathToCraddle(Transform craddle)
    {
        pathPoint = craddle;
        GoToDestination();
    }

=======
>>>>>>> parent of d3e71b0 (dwadawda)
    void GoToDestination()
    {
=======
    void GoToDestination() {
>>>>>>> develop
        agent.SetDestination(new Vector3(pathPoint.position.x, pathPoint.position.y, 0));
    }

    Transform GetRandomTargetPoint() {
        int randomPoint = Random.Range(0, targetPoints.Count - 1);
        pathPointController = targetPoints[randomPoint].GetComponent<PathPointController>();
        return targetPoints[randomPoint];
    }

    IEnumerator WaitNearPoint(float waiting) {
        yield return new WaitForSecondsRealtime(waiting);
        GoToDestination();
    }
}
