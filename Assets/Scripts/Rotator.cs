using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotator = 0f;
    public float direction = 0f;
    public float minStartingValue = 30f;
    public float maxStartingValue = 40f;

    private void Awake()
    {
        direction = Random.Range(-1f, 1f);
    }

    private void Start()
    {
        if (direction > 0)
        {
            rotator = Random.Range(-minStartingValue, -maxStartingValue);
        }
        else if (direction < 0)
        {
            rotator = Random.Range(minStartingValue, maxStartingValue);
        }
        else
        {
            rotator = 30f;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotator);
    }
}
