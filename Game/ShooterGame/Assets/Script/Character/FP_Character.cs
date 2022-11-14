using System.Collections;
using UnityEngine;

public class FP_Character : Entity
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.18f;
    private Vector3 velocity;
    [SerializeField] public Weapon weapon;
    [SerializeField] private StatsBar statsBar;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        statsBar.SetMaxHealth(_maxHealth);
        statsBar.SetMaxShield(_maxShield);
    }

    private void Update()
    {

    }

    override public void TakeDamage(float value) 
    {
        if(_currentShield > 0)
        {
            _currentShield -= value;
        }
        else
        {
            _currentHealth -= value;
        }
        statsBar.SetHealth(_currentHealth);
        statsBar.SetShield(_currentShield);
    }
  
     protected override void Death() 
    {
        Debug.Log("Low Hp You need More");
    }
}
