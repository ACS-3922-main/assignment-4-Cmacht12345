using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RPGCameraManager : MonoBehaviour
{
    private static RPGCameraManager _sharedInstance = null;
    public static RPGCameraManager SharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }
    private CinemachineVirtualCamera _virtualCamera;
    public CinemachineVirtualCamera VirtualCamera
    {
        get
        {
            return _virtualCamera;
        }
    }
    void Awake()
    {
        if (_sharedInstance != null && _sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _sharedInstance = this;
        }
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        _virtualCamera =
        vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
}
