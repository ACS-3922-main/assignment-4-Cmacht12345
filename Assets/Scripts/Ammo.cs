using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _damageInflicted = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DamageCharacter(_damageInflicted,
            0.0f));
            gameObject.SetActive(false);
        }
    }
}
