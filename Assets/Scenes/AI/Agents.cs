﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agents : MonoBehaviour
{
    public AgentAI AgentAIPrefab;
    public int AgentAICount;

    bool hasStarted = false;

    void Awake()
    {
        Random.InitState(87);
    }

    void Start()
    {

    }

    public void StartAI()
    {
        if (!hasStarted)
        {
            float range = 4.5f;

            for (int i = 0; i < AgentAICount; i++)
            {
                var agentAI = Instantiate(AgentAIPrefab);
                agentAI.transform.parent = this.transform;
                agentAI.transform.position = range * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }

            hasStarted = true;
        }
    }

    void Update()
    {
        
    }
}
