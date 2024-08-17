using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBplck : MonoBehaviour
{
    public Transform pos1, pos2;
    public int speed;
    Vector2 tragetpos;
    // Start is called before the first frame update
    void Start()
    {
        tragetpos = pos2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pos1.position) < .1f) tragetpos = pos2.position;
        if (Vector2.Distance(transform.position, pos2.position) < .1f) tragetpos = pos1.position;

        transform.position = Vector2.MoveTowards(transform.position, tragetpos, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
