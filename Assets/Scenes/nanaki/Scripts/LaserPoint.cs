﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    GameManager gm;
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
        bullet = 2;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

        if(bullet <= 0)
        {


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
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                bullet--;
                if(hitInfo.transform.tag == "Human")
                {
                    gm.Result(true);
                }

                if (bullet <= 0)
                    gm.Result(false);

                

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