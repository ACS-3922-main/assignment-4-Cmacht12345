using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float _hitPoints;
    [SerializeField] private int _damageStrength;
    private Coroutine _damageCoroutine;

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        StartCoroutine(FlickerCharacter());
        while (true)
        {
            _hitPoints = _hitPoints - damage;
            if (_hitPoints <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    public override void ResetCharacter()
    {
        _hitPoints = _startingHitPoints;
    }
    private void OnEnable()
    {
        ResetCharacter();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player =
            collision.gameObject.GetComponent<Player>();
            if (_damageCoroutine == null)
            {
                _damageCoroutine = StartCoroutine(player.
                DamageCharacter(_damageStrength, 1.0f));
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_damageCoroutine != null)
            {
                StopCoroutine(_damageCoroutine);
                _damageCoroutine = null;
            }
        }
    }
}
