using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerPlayerController : MonoBehaviour
{
    private GameObject RoboAvater;
    // Start is called before the first frame update
    void Start()
    {
        RoboAvater = GameObject.Find("Robot Kyle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 avaterPos = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        RoboAvater.transform.position = avaterPos;
        var moveDir = this.transform.rotation.eulerAngles.y;
        var moveQ = Quaternion.Euler(0, moveDir, 0);
        RoboAvater.transform.rotation = moveQ;

    }

    private void FixedUpdate()
    {
        
    }
}
