using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] Transform pathPoint;
    [SerializeField] List<Transform> targetPoints;
    [SerializeField] PathPointsCollection pathPointsCollection;
    [SerializeField] Animator animator;

    NavMeshAgent agent;
    PathPointController pathPointController;

    private void Start()
    {
        pathPointsCollection = FindAnyObjectByType<PathPointsCollection>();
        targetPoints = pathPointsCollection.ListPoints();
        agent = GetComponent<NavMeshAgent>();
        pathPoint = GetRandomTargetPoint();
        StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
    }

    private void Update()
    {
        if (!agent.hasPath)
        {
            pathPoint = GetRandomTargetPoint();
            StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
        }

        animator.SetBool("isWalking", agent.hasPath);
    }

    public void SetPathToBebok(Transform bebok)
    {
        pathPoint = bebok;
        StartCoroutine(WaitNearPoint(pathPointController == null ? 1f : pathPointController.WaitingFarThisPoint()));
    }


    public void SetPathToCraddle(Transform craddle)
    {
        pathPoint = craddle;
        GoToDestination();
    }

    void GoToDestination()
    {
        agent.SetDestination(new Vector3(pathPoint.position.x, pathPoint.position.y, 0));
    }

    Transform GetRandomTargetPoint()
    {
        int randomPoint = Random.Range(0, targetPoints.Count - 1);
        pathPointController = targetPoints[randomPoint].GetComponent<PathPointController>();
        return targetPoints[randomPoint];
    }

    IEnumerator WaitNearPoint(float waiting)
    {
        yield return new WaitForSecondsRealtime(waiting);
        GoToDestination();
    }

}
