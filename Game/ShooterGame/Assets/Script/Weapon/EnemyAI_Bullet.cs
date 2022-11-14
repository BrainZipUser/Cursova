using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private FP_Character player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
}
