using UnityEngine;
using uOSC;

public class ServerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        uOscServer server = GetComponent<uOscServer>();
        if (server == null) {
            throw new MissingComponentException("uOscServer could not be found.");
            server.onDataReceived.AddListener(OnDataReceived);
        }
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

        Debug.Log(msg);
    }
}
