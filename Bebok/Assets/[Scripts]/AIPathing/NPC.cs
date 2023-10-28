using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] Transform pathPoint;
    [SerializeField] List<Transform> targetPoints;
    [SerializeField] PathPointsCollection pathPointsCollection;

    NavMeshAgent agent;

    private void Start()
    {
        pathPointsCollection = FindAnyObjectByType<PathPointsCollection>();
        targetPoints = pathPointsCollection.ListPoints();
        agent = GetComponent<NavMeshAgent>();
        pathPoint = GetRandomTargetPoint();
        GoToDestination();
    }
    private void Update()
    {
        if (!agent.hasPath) 
        {
            pathPoint = GetRandomTargetPoint();
            GoToDestination();
        }
    }

    public void SetPathToBebok(Transform bebok)
    {
        pathPoint = bebok;
        GoToDestination();
    }

    void GoToDestination()
    {
        agent.SetDestination(new Vector3(pathPoint.position.x, pathPoint.position.y, 0));
    }

    Transform GetRandomTargetPoint()
    {
        int randomPoint = Random.Range(0, targetPoints.Count-1);
        return targetPoints[randomPoint];
    }

}
