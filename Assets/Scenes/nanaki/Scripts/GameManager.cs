using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private Image Win;
    private Image Lose;


    private MessageSendToClient messageSendToClient;
    private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        Win = GameObject.Find("Win").GetComponent<Image>();
        Lose = GameObject.Find("Lose").GetComponent<Image>();
        bgm = GameObject.Find("Audio").GetComponent<AudioSource>();
        messageSendToClient = FindObjectOfType<MessageSendToClient>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void Result(bool flg)
    {
        if (flg)
        {
            messageSendToClient.SendText("serverwon");
            Win.enabled = true;
            bgm.Stop();

        }
        else if (!flg)
        {
            Lose.enabled = true;
            messageSendToClient.SendText("clientwon");
        }

    }
}
