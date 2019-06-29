using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentHuman : MonoBehaviour
{
    NavMeshAgent _navAgent;

    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector3(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = new Vector3(0, 0, -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = new Vector3(1, 0, 0);
        }

        if (direction.sqrMagnitude > 0.01f)
        {
            Debug.Log("MOVE");
            direction = 0.5f * direction;
            _navAgent.destination = _navAgent.nextPosition + direction;
        }
    }
}
