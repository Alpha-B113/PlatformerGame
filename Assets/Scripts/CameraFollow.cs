using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    void Update()
    {
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);
    }
}
