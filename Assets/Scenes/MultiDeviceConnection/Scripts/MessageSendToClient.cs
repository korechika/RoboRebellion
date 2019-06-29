using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class MessageSendToClient : MonoBehaviour
{
    uOscClient client;

    void Start() {
        client = FindObjectOfType<uOscClient> ();
        SendText("Send from server.");
    }

    // Update is called once per frame
    void Update()
    {
        SendText("Update in MessageSendToClient.");
    }

    void SendText(string text)
    {
        client.Send("localhost", text);
    }
}
