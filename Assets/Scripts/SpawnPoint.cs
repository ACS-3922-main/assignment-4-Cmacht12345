using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private float _repeatInterval;
    [SerializeField] private float _maxInterval;
    private float _mobCount;
    public void Start()
    {
        if (_repeatInterval > 0)
        {
            InvokeRepeating("SpawnAmount", 0.0f, _repeatInterval);
            
        }
    }
    public GameObject SpawnObject()
    {
        if (_prefabToSpawn != null)
        {
        return Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);   
        }
        return null;
    }

    public GameObject SpawnAmount()
    {
        if (_prefabToSpawn != null)
        {
            if(_mobCount < _maxInterval)
            {
                _mobCount++;
                return Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
            }
        }
        return null;
    }
}
