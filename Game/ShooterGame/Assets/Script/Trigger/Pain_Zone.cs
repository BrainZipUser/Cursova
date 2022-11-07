using UnityEngine;

public class Pain_Zone : MonoBehaviour
{
    [SerializeField] private FP_Character character;
    [SerializeField] private float value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            character.TakeDamage(value);
        }
    }
}
