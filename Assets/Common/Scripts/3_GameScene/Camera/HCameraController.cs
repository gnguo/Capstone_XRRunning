using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCameraController : MonoBehaviour
{
    private Transform tPlayer;

    //카메라 위치
    private float yOffset = 2.5f;
    private float zOffset = -5.47f;


    void Start()
    {
        tPlayer = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {
        Vector3 pos= new Vector3(tPlayer.position.x,
                                         tPlayer.position.y + yOffset,
                                         tPlayer.position.z + zOffset);

        this.transform.position = pos;


    }
}

