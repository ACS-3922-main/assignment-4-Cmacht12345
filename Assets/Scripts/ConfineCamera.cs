using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConfineCamera : MonoBehaviour
{
    private PolygonCollider2D _currentCollider;
    private PolygonCollider2D _groundLayerOne;
    private PolygonCollider2D _groundLayerTwo;
    private CinemachineConfiner _cameraConfiner;
    private GameObject _player;

    void Start()
    {
        _cameraConfiner = GameObject.Find("CM vcam1").GetComponent<CinemachineConfiner>();
        _groundLayerOne = GameObject.Find("GroundLayer").GetComponent<PolygonCollider2D>();
        _groundLayerTwo = GameObject.Find("GroundLayerTwo").GetComponent<PolygonCollider2D>();
        _player = GameObject.Find("Player");
        _currentCollider = _groundLayerOne;
    }


    public void ChangeConfiner(float pos) 
    {
        if(pos < 8f && _currentCollider == _groundLayerTwo)
        {
            _currentCollider = _groundLayerOne;
            _cameraConfiner.m_BoundingShape2D = _currentCollider;
        }
        if(pos > 9 && _currentCollider == _groundLayerOne)
        {
            _currentCollider = _groundLayerTwo;
            _cameraConfiner.m_BoundingShape2D = _currentCollider;
        }
    }
}
