using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
    [SerializeField] Transform pathPoint;

    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(pathPoint.position.x, pathPoint.position.y,0));
    }
}
