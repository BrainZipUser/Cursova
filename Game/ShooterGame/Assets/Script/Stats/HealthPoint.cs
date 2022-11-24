using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float health;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FP_Character>().AddHealth(health);
            FindObjectOfType<AudioManager>().Play("HealthPoint");

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
