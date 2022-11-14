using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
