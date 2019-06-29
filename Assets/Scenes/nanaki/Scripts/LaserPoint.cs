using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserPoint : MonoBehaviour
{
    GameManager gm;
    bool result;
    [SerializeField]
    private Transform _RightHandAnchor;

    [SerializeField]
    private Transform _LeftHandAnchor;

    [SerializeField]
    private Transform _CenterEyeAnchor;

    [SerializeField]
    private float _MaxDistance = 100.0f;

    [SerializeField]
    private LineRenderer _LaserPointerRenderer;


    public int bullet;
    private AudioSource sound;
    private Transform Pointer
    {
        get
        {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();

            return _RightHandAnchor;
          
        }
    }
    private void Start()
    {
        bullet = 99999;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sound = GameObject.Find("Sound").GetComponent<AudioSource>();

    }
    void Update()
    {

        if(result)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
                SceneManager.LoadScene(0);
                return;
        }

        var pointer = Pointer;
        if (pointer == null || _LaserPointerRenderer == null)
        {
            return;
        }
        // コントローラー位置からRayを飛ばす
        Ray pointerRay = new Ray(pointer.position, pointer.forward);

        // レーザーの起点
        _LaserPointerRenderer.SetPosition(0, pointerRay.origin);

        RaycastHit hitInfo;
        if (Physics.Raycast(pointerRay, out hitInfo, _MaxDistance))
        {
            // Rayがヒットしたらそこまで
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Debug.Log("うったよ");

                sound.Play();
                bullet--;
                if(hitInfo.transform.name == "AgentHuman" )
                {
                    result = true;
                    gm.Result(true);
                }

                if (bullet <= 0)
                {
                    result = true;
                    Destroy(_LaserPointerRenderer);
                    gm.Result(false);
                }

                

            }
            _LaserPointerRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
        }
    }

   
}