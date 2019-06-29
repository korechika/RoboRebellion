using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

public class CameraTransformSender : MonoBehaviour
{
    uOscClient client;
    Camera camera;

    void Awake()
    {
        client = FindObjectOfType<uOscClient> ();
        camera = FindObjectOfType<Camera>();
    }

	void Start () {
        SendText("start");
	}

	void Update () {
		SendTransformToServer (camera.transform.position, camera.transform.rotation.eulerAngles);
	}

    void SendText(string text)
    {
        client.Send("localhost", text);
        Debug.Log("Send: " + text); 
    }

    void SendTransformToServer(Vector3 pos, Vector3 rot)
    {
        client.Send("localhost", pos.x + " " + pos.y + " " + pos.z + " " + rot.x + " " + rot.y + " " + rot.z);
    }
}
