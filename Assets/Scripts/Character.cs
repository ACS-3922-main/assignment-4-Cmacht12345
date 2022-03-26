using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public enum CharacterCategory
{
    Player,
    Enemy
}

public abstract class Character : MonoBehaviour
{
    public CharacterCategory characterCategory;
    [SerializeField] protected float _maxHitPoints = 10;
    [SerializeField] protected float _startingHitPoints = 5;
    public float MaxHitPoints
    {
        get
        {
            return _maxHitPoints;
        }
        set
        {
            _maxHitPoints = value;
        }
    }

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(int damage, float interval);
    public virtual IEnumerator FlickerCharacter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}