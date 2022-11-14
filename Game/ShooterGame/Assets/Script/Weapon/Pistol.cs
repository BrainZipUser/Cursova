using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Weapon
{
    /*[SerializeField] private Text ammoText;

    private void Start()
    {
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    public void Reload()
    {
        if (canReload && currentAmmo < clipAmmo)
        {
            int decrice = clipAmmo - currentAmmo;
            if (maxAmmo - decrice <= 0 || maxAmmo < clipAmmo)
                maxAmmo = 0;
            else
                maxAmmo -= decrice;
            currentAmmo = clipAmmo;
            ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
        }
    }

    public bool isWeaponCanShoot() 
    {
        if (canShoot && currentAmmo > 0)
            return true;
        else
            return false;
    }

    public IEnumerator Shoot()
    {
        if (canShoot && currentAmmo > 0)
        {
            currentAmmo--;
            AudioSource AudioSource = GetComponent<AudioSource>();
            AudioSource.Play();
            RaycastHit hit;

            if (muzzleFlash != null)
            {
                muzzleFlash.Play();
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {

                EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                //Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            canShoot = false;
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
            ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
        }
    }
    */
}
