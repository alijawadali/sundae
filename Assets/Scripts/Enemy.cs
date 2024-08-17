using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set In Inspector")]
    public float speed = 5f;
    public float movingRange = 3;
    public float turnRange = 20f;
    public float damagePerSecond = 3;

    [Header("Set Dynamically")]
    [SerializeField] private bool isFlipping = false;

    private Vector3 startingPosition;
    private Vector3 direction = Vector3.right;

    private float flipDirection;

    private void Start()
    {
        direction = Random.value >= 0.5f ? Vector3.right : Vector3.left;

        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!CheckInSideRange() && !isFlipping)
            StartCoroutine(FlipDirection());

        var targetPosition = startingPosition + direction * movingRange;
        transform.position += direction * speed * Time.fixedDeltaTime;

        transform.eulerAngles = Vector3.forward * Mathf.LerpAngle(transform.eulerAngles.z, turnRange * -direction.x, Time.fixedDeltaTime * speed);
    }

    IEnumerator FlipDirection()
    {
        isFlipping = true;

        var defualtDirectionX = direction.x;
        var targetDirection = -direction.x;

        var movingVariable = 0f;
        var movingSpeed = 1f;
        var t = 0f;

        while(movingVariable <= Mathf.PI / 2)
        {
            yield return new WaitForFixedUpdate();

            movingVariable += (Mathf.PI / 2) * movingSpeed * Time.fixedDeltaTime;
            t = Mathf.Sin(movingVariable);

            direction.x = Mathf.Lerp(defualtDirectionX, targetDirection, t);
        }

        isFlipping = false;
    }

    private bool CheckInSideRange()
    {
        return transform.position.x <= startingPosition.x + movingRange &&
            transform.position.x >= startingPosition.x - movingRange;
    }
}
