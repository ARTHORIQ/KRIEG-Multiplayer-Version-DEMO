using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MultiPlayerCameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

}
