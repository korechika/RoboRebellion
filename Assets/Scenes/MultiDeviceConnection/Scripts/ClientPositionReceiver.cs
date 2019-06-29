using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class ClientPositionReceiver : MonoBehaviour
{
    uOscServer server;

    void Awake()
    {
        server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(Message message)
    {
        // OSC のアドレス
        var msg = message.address + ": ";

        // object[] として OSC の引数がやってくる
        foreach (var value in message.values)
        {
            if      (value is int)    msg += (int)value;
            else if (value is float)  msg += (float)value;
            else if (value is string) msg += (string)value;
            else if (value is byte[]) msg += "byte[" + ((byte[])value).Length + "]";
        }

        string[] msgs = message.values[0].GetString().Split(' ');
        if (msgs.Length == 6) {
            Vector3 pos = GetPositionFromMsg (msgs);
            Vector3 rot = GetRotationFromMsg (msgs);
            Debug.Log("pos:" + pos + ", rot:" + rot);
            // m_onTransformReceived.Invoke (pos, rot);
        }
    }

    private Vector3 GetPositionFromMsg (string[] msgs) {
        return new Vector3 (float.Parse(msgs [0]), float.Parse(msgs [1]), float.Parse(msgs [2]));
    }

    private Vector3 GetRotationFromMsg (string[] msgs) {
        return new Vector3 (float.Parse(msgs [3]), float.Parse(msgs [4]), float.Parse(msgs [5]));
    }
}
