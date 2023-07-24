using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Vector3 center;
    public Vector3 initialPosition;

    public float speed = 1f;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), step);

        if (Vector3.Distance(transform.position, new Vector3(0f, 0f, 0f)) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
