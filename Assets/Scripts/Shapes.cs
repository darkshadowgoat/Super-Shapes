using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public Rigidbody2D rb;

    public float shrinkSpeed = 3.0f;

    public Player player;

    private void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;    
    }

    private void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
