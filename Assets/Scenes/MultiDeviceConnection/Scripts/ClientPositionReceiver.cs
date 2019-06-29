using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class ClientPositionReceiver : MonoBehaviour
{
    public Vector3 clientPos { get; private set; }
    public Vector3 clientRot { get; private set; }
    public uOscServer server;
    GameObject cube;

    void Awake()
    {
        // server = FindObjectOfType<uOscServer>();
        if (server == null) {
            Debug.Log("uOscServer could not be found.");
        }
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void Start() {
        clientPos = Vector3.zero;
        clientRot = Vector3.zero;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        UpdateTransform(cube);
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
            clientPos = pos;
            clientRot = rot;
            Debug.Log("pos:" + pos + ", rot:" + rot);
            UpdateTransform(cube);
            // m_onTransformReceived.Invoke (pos, rot);
        }
    }

    Vector3 GetPositionFromMsg (string[] msgs) {
        return new Vector3 (float.Parse(msgs [0]), float.Parse(msgs [1]), float.Parse(msgs [2]));
    }

    Vector3 GetRotationFromMsg (string[] msgs) {
        return new Vector3 (float.Parse(msgs [3]), float.Parse(msgs [4]), float.Parse(msgs [5]));
    }

    void UpdateTransform(GameObject obj) {
        obj.transform.position = clientPos;
        obj.transform.eulerAngles = clientRot;
    }
}
