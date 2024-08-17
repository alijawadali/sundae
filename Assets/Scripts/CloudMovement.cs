using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 direction = Vector2.right;

    private void Start()
    {
        StartCoroutine(UpdateMovementParameters());
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    IEnumerator UpdateMovementParameters()
    {
        direction = Random.value >= 0.5f ? Vector3.right : Vector3.left;

        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5, 7));
            direction *= -1;      
        }
    }
}
