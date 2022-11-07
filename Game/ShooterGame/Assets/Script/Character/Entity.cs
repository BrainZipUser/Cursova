using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float shield;
    private bool isDead = false;

    public bool IsDead{ get { return isDead; } }
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    public Entity() 
    {
        _currentHealth = 100;
        _maxHealth = 100;
    }

    public Entity(float currentHealth , float maxHealth) 
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
    }

    public virtual void TakeDamage(float value)
    {
        _currentHealth -= value;
        if(_currentHealth <= 0) 
        {
            Death();
        }
    }
    protected virtual void Death() 
    {
        Destroy(gameObject);
        Debug.Log("Low Health");
    }
}
