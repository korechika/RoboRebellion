using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour
{
    public AgentAI AgentAIPrefab;
    public int AgentAICount;

    void Start()
    {
        for (int i = 0; i < AgentAICount; i++)
        {
            var agentAI = Instantiate(AgentAIPrefab);
            agentAI.transform.parent = this.transform;
            agentAI.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        }
    }

    void Update()
    {
        
    }
}
