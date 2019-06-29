using System.Collections;
using System.Collections.Generic;
using AnimatorStateMachineUtil;
using UnityEngine;

public class AgentAIStateIdle : MonoBehaviour
{
    AgentAI _agentAI;
    Animator _animator;

    void Start()
    {
        _agentAI = GetComponent<AgentAI>();
        _animator = GetComponent<Animator>();
    }

    [StateEnterMethod("Base.Idle")]
    public void OnStateEnter()
    {
        Debug.Log("Idle");
        var idleDuration = Random.Range(3f, 10f);
        StartCoroutine(ChangeDestinationDelay(idleDuration));
    }

    [StateUpdateMethod("Base.Idle")]
    public void OnStateUpdate()
    {

    }

    IEnumerator ChangeDestinationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool("walk", true);
    }
}
