using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    void Update()
    {
        transform.position = CameraPosition.transform.position;
    }
}
