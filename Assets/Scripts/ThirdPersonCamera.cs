using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // The player's transform
    public Vector3 offset;    // The camera's offset from the player

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}
