using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private FP_Character player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }

        if (other.gameObject.tag != "Player" && gameObject != null)
        {
            Destroy(gameObject, 1.5f);
        }

    }
}
