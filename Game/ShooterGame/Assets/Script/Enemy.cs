using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float shield;
    private bool isDead = false;

    public bool IsDead{ get { return isDead; } }
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    public Enemy() 
    {
        _currentHealth = 100;
        _maxHealth = 100;
    }

    public Enemy(float currentHealth , float maxHealth) 
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
    }

    public void TakeDamage(float value)
    {
        _currentHealth -= value;
        if(_currentHealth <= 0) 
        {
            Death();
        }
    }
    protected virtual void Death() 
    {
        Debug.Log("Low Health");
    }
}
