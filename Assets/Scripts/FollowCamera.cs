using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -5);

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}
