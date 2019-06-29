using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class AgentAIStateWalk : MonoBehaviour
{
    AgentAI _agentAI;
    Animator _animator;

    void Start()
    {
        _agentAI = GetComponent<AgentAI>();
        _animator = GetComponent<Animator>();
    }

    [StateEnterMethod("Base.Walk")]
    public void OnStateEnter()
    {
        Debug.Log("Walk");
        _agentAI.ChangeSpeed();
        _agentAI.ChangeDestination();
    }

    [StateUpdateMethod("Base.Walk")]
    public void OnStateUpdate()
    {
        if (_agentAI.HasArrivedDestination())
        {
            _animator.SetBool("walk", false);
        }
    }
}
