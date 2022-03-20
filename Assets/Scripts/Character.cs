using UnityEngine;

public abstract class Character : MonoBehaviour {
    [SerializeField] protected int _maxHitPoints = 10;
    [SerializeField] protected float _hitPoints = 5;

    public int MaxHitPoints {
        get { 
            return _maxHitPoints; 
        } 
        set { 
            _maxHitPoints = value; 
        } 
    }
}