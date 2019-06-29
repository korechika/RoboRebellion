using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    static int Priority = 0;

    NavMeshAgent _navAgent;

    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.avoidancePriority = AgentAI.Priority++;
    }

    void Update()
    {

    }

    public void ChangeSpeed()
    {
        _navAgent.speed = Random.Range(1f, 2f);
    }

    public void ChangeDestination()
    {
        _navAgent.destination = new Vector3(Random.Range(-4.5f, 4.5f), 0, Random.Range(-4.5f, 4.5f));
    }

    public bool HasArrivedDestination()
    {
        if (!_navAgent.pathPending)
        {
            if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
            {
                if (!_navAgent.hasPath || _navAgent.velocity.sqrMagnitude < 0.5f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
