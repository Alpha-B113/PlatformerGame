using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform followTransform;

    void FixedUpdate()
    {
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);
    }
}
