using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RPGGameManager : MonoBehaviour
{
    
    [SerializeField] private SpawnPoint _playerSpawnPoint;
    [SerializeField] private RPGCameraManager _cameraManager;
    private static RPGGameManager _sharedInstance = null;
    public static RPGGameManager SharedInstance
    {
        get { return _sharedInstance; }
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
    }
    void Start()
    {
        SetupScene();
    }
    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (_playerSpawnPoint != null)
        {
            GameObject player =
            _playerSpawnPoint.SpawnObject();
            _cameraManager.VirtualCamera.Follow = player.transform;
        }
        
    }
}
