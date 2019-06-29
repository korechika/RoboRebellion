using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    float _initialY;
    float _totalT;
    float _velocity;

    void Start()
    {
        _totalT = 0;
        _velocity = Random.Range(1.5f, 3f);
        _initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        _totalT += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, _initialY + 5 * Mathf.Sin(_totalT/ _velocity), transform.position.z);
    }
}
