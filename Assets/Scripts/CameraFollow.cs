using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public float offset;

    void Update()
    {
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y + offset, transform.position.z);
    }
}
