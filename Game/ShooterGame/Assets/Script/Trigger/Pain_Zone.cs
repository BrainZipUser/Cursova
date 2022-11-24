using UnityEngine;

public class Pain_Zone : MonoBehaviour
{
    [SerializeField] private float value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<FP_Character>().TakeDamage(value);
        }
    }
}
