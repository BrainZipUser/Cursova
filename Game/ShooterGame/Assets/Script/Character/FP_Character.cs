using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FP_Character : Entity
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.18f;
    private Vector3 velocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGround;
    [SerializeField] private float JumpHeight = 3f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform Camera;
    [SerializeField] private Animator animator;
    [SerializeField] static private float MaxHealth = 100f;
    [SerializeField] public Pistol pistol;
    private float xRotation = 0f;
    [SerializeField] HealthBar healthBar;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        animator.SetFloat("Speed", horizontalSpeed);

        if (Input.GetButtonDown("Jump"))
            Jump();
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootPistol());
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            pistol.Reload();
        }
    }

    override public void TakeDamage(float value) 
    {
        _currentHealth -= value;
        healthBar.SetHealth(_currentHealth);
    }

    IEnumerator ShootPistol() 
    {
        if (pistol.isWeaponCanShoot())
        {
            pistol.StartCoroutine(pistol.Shoot());
            animator.SetBool("CanShoot", true);
            yield return new WaitForSeconds(pistol.GetFireRate);
            animator.SetBool("CanShoot", false);
        }
    }

    /*public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Turn()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", x);

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }*/

    public void Jump() 
    {
        if (isGround)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
    }
    
     protected override void Death() 
    {
        Debug.Log("Low Hp You need More");
    }
}
