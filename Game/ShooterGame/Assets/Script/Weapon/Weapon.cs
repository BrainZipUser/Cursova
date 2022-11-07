using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected int clipAmmo;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected Camera fpsCam;
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected ParticleSystem impactEffect;
    [SerializeField] protected float fireRate = 15;
    [SerializeField] protected AudioClip FireSound;
    protected bool canReload = true;
    protected bool canShoot = true;
    protected float nextTimeToFire = 0;

    public bool CanShoot { get { return canShoot; } }
    public float GetFireRate { get { return fireRate; } }
}
