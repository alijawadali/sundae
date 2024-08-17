
using UnityEngine;

public class CameraF : MonoBehaviour
{
    public Transform target;
    [Range(1,10)]
    public float smoothSpeed;
    public Vector3 offset;




    private void FixedUpdate()
    {
        //   Vector3 smoothePosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
      Vector3 smoothePosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed*Time.fixedTime);
        transform.position = smoothePosition;
    }
}
