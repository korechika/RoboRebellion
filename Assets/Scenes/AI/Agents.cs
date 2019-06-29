using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour
{
    public AgentAI AgentAIPrefab;
    public int AgentAICount;

    bool hasStarted = false;

    private AgentHuman _agentHuman;

    void Awake()
    {
        Random.InitState(87);
        _agentHuman = FindObjectOfType<AgentHuman>();
        _agentHuman.transform.localScale = Vector3.zero;
    }

    void Start()
    {

    }

    public void StartAI()
    {
        if (!hasStarted)
        {
            hasStarted = true;

            float range = 4.5f;

            for (int i = 0; i < 4; i++)
            {
                var agentAI = Instantiate(AgentAIPrefab);
                agentAI.transform.parent = this.transform;
                agentAI.transform.position = range * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }

            _agentHuman.transform.localScale = Vector3.one;
        }
    }

    void Update()
    {
        
    }
}
