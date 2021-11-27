using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothnessSpeed;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;


    void LateUpdate ()
    {
        Vector3 playerPosition = target.position + offset;
        transform.position = playerPosition;
    }
}
