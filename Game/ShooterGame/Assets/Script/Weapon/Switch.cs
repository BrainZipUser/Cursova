using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Grappling grappling;
    [SerializeField] private KeyCode switchToPrimery = KeyCode.Mouse2;

    private void Start()
    {
        SetStartEqueppment();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchToPrimery))
        {
            SwitchWeapon();
        }
    }

    public void SwitchWeapon()
    {
        if (weapon.IsEquepped && !(grappling.IsEquepped))
        {
            weapon.IsEquepped = false;
            grappling.IsEquepped = true;

            weapon.gameObject.SetActive(false);
            grappling.gameObject.SetActive(true);
        }
        else if (!(weapon.IsEquepped) && grappling.IsEquepped)
        {
            weapon.IsEquepped = true;
            grappling.IsEquepped = false;

            weapon.gameObject.SetActive(true);
            grappling.gameObject.SetActive(false);
        }
    }

    private void SetStartEqueppment()
    {
        weapon.IsEquepped = true;
        grappling.IsEquepped = false;

        weapon.gameObject.SetActive(true);
        grappling.gameObject.SetActive(false);
    }
}
