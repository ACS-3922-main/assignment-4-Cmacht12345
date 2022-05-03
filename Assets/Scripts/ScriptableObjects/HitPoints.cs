using UnityEngine;

[CreateAssetMenu(fileName = "New HitPoints", menuName = "HitPoints", order = 52)]

public class HitPoints : ScriptableObject
{
    [SerializeField] private float _value;
    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
}

