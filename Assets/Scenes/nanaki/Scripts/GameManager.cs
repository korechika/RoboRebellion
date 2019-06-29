using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void Result(bool flg)
    {
        if (flg)
        {
            bgm.Stop();

        }
        else if (!flg)
        {

        }

    }
}
