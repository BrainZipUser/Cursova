using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPoint : MonoBehaviour
{
    [SerializeField] private int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FP_Character>().weapon.AddAmmo(ammo);
            FindObjectOfType<AudioManager>().Play("AmmoPoint");

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
