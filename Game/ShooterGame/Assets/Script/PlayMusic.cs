using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }
}
