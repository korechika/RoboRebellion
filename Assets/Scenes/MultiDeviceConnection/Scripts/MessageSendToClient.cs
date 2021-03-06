﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class MessageSendToClient : MonoBehaviour
{
    uOscClient client;
    Agents _agents;

    void Start() {
        client = FindObjectOfType<uOscClient> ();
        SendText("Send from server.");

        _agents = FindObjectOfType<Agents>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two))
        {
            SendText("gamestart");
            _agents.StartAI();
        }
    }

    public void SendText(string text)
    {
        client.Send("localhost", text);
    }
}
