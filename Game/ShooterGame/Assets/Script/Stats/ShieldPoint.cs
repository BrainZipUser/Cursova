using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPoint : MonoBehaviour
{
    [SerializeField] private float shield;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FP_Character>().AddShield(shield);
            FindObjectOfType<AudioManager>().Play("ShieldPoint");
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
