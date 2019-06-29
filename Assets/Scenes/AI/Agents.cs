﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour
{
    public AgentAI AgentAIPrefab;
    public int AgentAICount;

    void Start()
    {
        float range = 4.5f;

        for (int i = 0; i < AgentAICount; i++)
        {
            var agentAI = Instantiate(AgentAIPrefab);
            agentAI.transform.parent = this.transform;
            agentAI.transform.position = range * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }
    }

    void Update()
    {
        
    }
}
