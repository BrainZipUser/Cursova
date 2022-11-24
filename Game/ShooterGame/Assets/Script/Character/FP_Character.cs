using UnityEngine;
using UnityEngine.SceneManagement;

public class FP_Character : Entity
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.18f;
    private Vector3 velocity;
    [SerializeField] public Weapon weapon;
    [SerializeField] private StatsBar statsBar;
    [SerializeField] private GameObject gameOverPanel;
    static public bool isPlay = true;
    private CapsuleCollider collision;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        statsBar.SetMaxHealth(_maxHealth);
        statsBar.SetMaxShield(_maxShield);

        collision = GetComponent<CapsuleCollider>();

        Time.timeScale = 1f;
    }

    private void Update()
    {

    }

    public void AddHealth(float value)
    {
        if (_currentHealth + value > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += value;
        }
        statsBar.SetHealth(_currentHealth);
    }

    public void AddShield(float value)
    {
        if(_currentShield + value > _maxShield)
        {
            _currentShield = _maxShield;
        }
        else
        {
            _currentShield += value;
        }
        statsBar.SetShield(_currentShield);
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

        if(_currentHealth <= 0) 
        {
            FindObjectOfType<AudioManager>().Play("Loose");
            Invoke("Death" , 1f);
        }
    }
  
     protected override void Death() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        isPlay = false;
        collision.isTrigger = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Low Hp You need More");
    }
}
