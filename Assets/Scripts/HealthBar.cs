using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HitPoints _hitPoints;
    [SerializeField] private Image _meterImage;
    [SerializeField] private Text _hpText;
    private float _maxHitPoints;
    private Player _character;
    public Player Character
    {
        get
        {
            return _character;
        }
        set
        {
            _character = value;
        }
    }
    void Start()
    {
        _maxHitPoints = _character.MaxHitPoints;
    }
    void Update()
    {
        if (_character != null)
        {
            _meterImage.fillAmount = _hitPoints.Value / _maxHitPoints;
            _hpText.text = "HP:" + (_meterImage.fillAmount * 100);
        }
    }
}
